using System.Collections.Generic;

namespace HomeworkApp.Data
{
    public class Storage<T>
    {
        private List<T> _table = new List<T>();

        public List<T> Table { get { return _table; } }
    }
}
