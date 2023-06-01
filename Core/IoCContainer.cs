using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTradersApp.Core;

class IoCContainer
{
    private static readonly IoCContainer instance = new IoCContainer();

    public static IServiceProvider? MyServiceProvider { get; set; }

    public static IoCContainer Instance { get { return instance; } }

    static IoCContainer() { }

    private IoCContainer() { }
}
