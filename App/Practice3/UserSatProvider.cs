namespace App.Practice3;

public static class UserSatProvider  
{  
    public static UserActionStatResponse GetUserActionStat(
        UserActionStatRequest request, 
        List<UserActionItem> userActionItems)  
    {
        var dict = GetStatDictionary(userActionItems, request);
        var userActionStatResponse = new UserActionStatResponse()
        {
            UserActionStat = GetStatList(dict, request.DateGroupType)
        };
        return userActionStatResponse;
    }
    private static Tuple<Dictionary<DateTime, Dictionary<ActionTypes, int>>, (DateTime, DateTime)[]> GetStatDictionary(
        List<UserActionItem> userActionItems, 
        UserActionStatRequest request)
    {
        var dateRangeInMonths= request.DateGroupType == DateGroupTypes.Monthly ? 
            InitDateRangeArray() : null;
        
        var userActionStatItems = new Dictionary<DateTime, Dictionary<ActionTypes, int>>();
        foreach (var userActionItem in userActionItems.Where(x => 
                     x.Date >= request.StartDate && x.Date <= request.EndDate))
        {
            var key = request.DateGroupType == DateGroupTypes.Monthly ? 
                new DateTime(userActionItem.Date.Year, userActionItem.Date.Month, 1) : userActionItem.Date;
            
            userActionStatItems.TryAdd(key, new Dictionary<ActionTypes, int>());
            userActionStatItems[key].TryAdd(userActionItem.Action, 0);
            
            userActionStatItems[key][userActionItem.Action] += userActionItem.Count;

            if (request.DateGroupType == DateGroupTypes.Monthly)
                UpdateDateRange(dateRangeInMonths, userActionItem.Date);
        }
        return Tuple.Create(userActionStatItems, dateRangeInMonths);
    }
    private static List<UserActionStatItem> GetStatList(
        Tuple<Dictionary<DateTime, Dictionary<ActionTypes, int>>, (DateTime, DateTime)[]> dict,
        DateGroupTypes dateGroupType)
    {
        var listStats = new List<UserActionStatItem>();
        foreach (var dictItem in dict.Item1)
        {
            var startDate = dateGroupType == DateGroupTypes.Monthly ? 
                dict.Item2[dictItem.Key.Month - 1].Item1
                : dictItem.Key;
            
            var endDate = dateGroupType == DateGroupTypes.Monthly ? 
                dict.Item2[dictItem.Key.Month - 1].Item2
                : dictItem.Key;
            
            listStats.Add(new UserActionStatItem{StartDate = startDate, EndDate = endDate, ActionMetrics = dictItem.Value});
        }
        return listStats;
    }
    private static (DateTime, DateTime)[] InitDateRangeArray()
    {
        var dateRangeInMonths = new (DateTime, DateTime)[12];
        
        for (int i = 0; i < dateRangeInMonths.Length; i++)
        {
            dateRangeInMonths[i] = (DateTime.MaxValue, DateTime.MinValue);
        }

        return dateRangeInMonths;
    }
    private static void UpdateDateRange((DateTime, DateTime)[] dateRangeInMonths, DateTime date)
    {
        if (date > dateRangeInMonths[date.Month - 1].Item2)
        {
            dateRangeInMonths[date.Month - 1].Item2 = date;
        }
        if (date < dateRangeInMonths[date.Month - 1].Item1)
        {
            dateRangeInMonths[date.Month - 1].Item1 = date;
        }
    }
}