using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using SDMX.Parsers;
using System.Xml;
using System.IO;

namespace SDMX
{
    public interface IMessage
    {
        Header Header { get; set; }
        string ToString();
    }
}
