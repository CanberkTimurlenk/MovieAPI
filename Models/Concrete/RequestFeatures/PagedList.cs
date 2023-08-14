using Models.Abstract.Entities;
using Models.Abstract.RequestFeatures;
using System.Collections;

namespace Models.Concrete.RequestFeatures
{
    public class PagedList<T> : IEnumerable<T>
        where T : class, IEntity, new()
    {
        private readonly List<T> _list = new List<T>();
        public MetaData MetaData { get; set; }

        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            _list.AddRange(items);

            MetaData = new MetaData()
            {
                PageSize = pageSize,
                CurrentPage = pageNumber,
                TotalCount = count,
                TotalPages = (count % pageSize) == 0 ? (count / pageSize) : (count / pageSize + 1)

            };
        }

        public static PagedList<T> ToPagedList(IEnumerable<T> source, RequestParameters requestParameters)
        {
            int count = source.Count();

            return new PagedList<T>(source.ToList(), count, requestParameters.PageNumber, requestParameters.PageSize);

        }

        public IEnumerator<T> GetEnumerator()
            => _list.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
