#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

#endregion

namespace RAA_QandA_230302
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            // put any code needed for the form here
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            //collector.OfCategory(BuiltInCategory.OST_Views);
            collector.OfCategory(BuiltInCategory.OST_VolumeOfInterest);

            List<Element> elemList = new List<Element>();

            //foreach(Element curElem in collector)
            //{
            //    View curView = curElem as View;

            //    if(curView.IsTemplate == true)
            //        elemList.Add(curElem);
            //}


            // open form
            MyForm currentForm = new MyForm(collector.ToList())
            {
                Width = 800,
                Height = 450,
                WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen,
                Topmost = true,
            };

            currentForm.ShowDialog();

            if(currentForm.DialogResult == true)
            {
                List<Element> selectedItems = currentForm.GetSelectedItemsWPF();
            }

            // get form data and do something

            return Result.Succeeded;
        }

        public static String GetMethod()
        {
            var method = MethodBase.GetCurrentMethod().DeclaringType?.FullName;
            return method;
        }
    }
}
