using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudOop.Models;

public class Cars
{
    public Guid Id { get; set; }
    public string Model { get; set; }
    public int OwnerAmount { get; set; }
    public int RunMilage { get; set; }
    public string color { get; set; }
    public string where { get; set; }
}
