using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerWeb.Models
{
    public class selectdb
    {
        private computerdbContext _computerdbContext = new computerdbContext();
        public selectdb() {       }
        public IQueryable selectcomputer() {
            var a = from abc in _computerdbContext.Province
                    select abc;
            return null;
        }
    }
}
