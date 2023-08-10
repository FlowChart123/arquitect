using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class InputPage
    {

        private int _page;

        private int _size;

        public int page { get { return _page; } set { _page = value < 1 ? 1:value; } }
        public int size { get { return _size; } set { _size= value < 1 ? 1 : value; } }
        public string? ordeBy { get; set; }
        public string? orderDirection { get; set; }
        public string? search { get; set; }

        public InputPage() {
            this.page = 1;
            this.size = 10;
        }
    }
}
