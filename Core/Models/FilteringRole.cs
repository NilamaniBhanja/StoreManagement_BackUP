using StoreManagement.Extensions;

namespace StoreManagement.Core.Models
{
    public class FilteringRole: IQueryObject
    {
        public string FilterByName { get; set; }
    }
}