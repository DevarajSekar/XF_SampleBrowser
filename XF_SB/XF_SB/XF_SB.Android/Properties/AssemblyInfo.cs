using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Android.App;
using Xamarin.Forms;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("XF_SB.Android")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("XF_SB.Android")]
[assembly: AssemblyCopyright("Copyright ©  2014")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

// Add some common permissions, these can be removed if not needed
[assembly: UsesPermission(Android.Manifest.Permission.Internet)]
[assembly: UsesPermission(Android.Manifest.Permission.WriteExternalStorage)]

[assembly: ExportFont("Poppins-Bold.ttf", Alias = "poppinsbold")]
[assembly: ExportFont("Poppins-Light.ttf", Alias = "poppinslight")]
[assembly: ExportFont("Ubuntu-Light.ttf", Alias = "ubunturegular")]
[assembly: ExportFont("Ubuntu-Regular.ttf", Alias = "ubuntulight")]
[assembly: ExportFont("Ubuntu-Bold.ttf", Alias = "ubuntubold")]
