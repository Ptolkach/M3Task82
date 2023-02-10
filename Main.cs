using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M3Task82
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Document doc = commandData.Application.ActiveUIDocument.Document;

                View3D view3D = new FilteredElementCollector(doc)
                    .OfClass(typeof(View3D))
                    .Cast<View3D>()
                    .FirstOrDefault(v => v.ViewType == ViewType.ThreeD && v.Name.Equals("{3D}"));

                var nwcOption = new NavisworksExportOptions();

                doc.Export(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "export.nwc", nwcOption);

            return Result.Succeeded;
        }
    }
}
