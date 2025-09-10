using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mutagen.Bethesda.WPF.Reflection.Attributes;

namespace HorsesFleeFromCombat
{
    public class Settings
    {

        public List<string[]> ParseIdFilters(IList<string> filterData)
        {
            List<string[]> result = new List<string[]>();
            foreach (var filterDataItem in filterData)
            {
                if (!String.IsNullOrEmpty(filterDataItem))
                {
                    string[] filterElements = filterDataItem.Split(new char[] {',',';'});
                    if (filterElements.Length > 0)
                    {
                        result.Add(filterElements);
                    }
                }
            }
            return result;
        }

        [MaintainOrder]
        private List<string[]> _blacklist = new List<string[]>();
        [SettingName("Blacklist")]
        [Tooltip("Editor IDs and names can be used to blacklist horses from being patched.")]
        public List<string> Blacklist
        {
            get
            {
                List<string> idFilters = new List<string>();
                foreach (var filter in _blacklist)
                {
                    idFilters.Add(String.Join(",", filter));
                }
                return idFilters;
            }
            set
            {
                _blacklist = ParseIdFilters(value);
            }
        }
    }
}
