using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop2.Core.Dtos
{
    public class CarExistingFilePathDto
    {
        public Guid? PhotoId { get; set; }
        public string FilePath { get; set; }
        public Guid? CarId { get; set; }
    }
}
