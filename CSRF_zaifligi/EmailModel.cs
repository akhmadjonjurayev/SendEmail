using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSRF_zaifligi
{
    public class EmailModel
    {
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        public string Text { get; set; }
    }
}
