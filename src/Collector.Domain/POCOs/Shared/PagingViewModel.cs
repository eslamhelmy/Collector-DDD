using System.Collections.Generic;

namespace Collector.Domain.ViewModels
{
    public class PagingViewModel<T>
    {
        public int Records { set; get; }
        public int Pages { set; get; }
        public IEnumerable<T> Result { set; get; }
    }
}
