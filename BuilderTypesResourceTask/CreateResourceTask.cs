using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Text;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace BuilderTypes
{
    public class CreateResourceTask : Task
    {
        [Required]
        public string ResourceFile { get; set; }
        public override bool Execute()
        {
            //System.Diagnostics.Debugger.Launch();
            var solutionDirectory = new FileInfo(Assembly.GetExecutingAssembly().Location).Directory.Parent.Parent.Parent.Parent;
            var builderTypesFolder = Path.Combine(solutionDirectory.FullName, "BuilderTypes", "Builder types");
            var csFiles = Directory.GetFiles(builderTypesFolder);
            using (ResourceWriter rw = new ResourceWriter(ResourceFile))
            {
                foreach(var csFile in csFiles)
                {
                    rw.AddResource(Path.GetFileNameWithoutExtension(csFile), File.ReadAllText(csFile));
                }
            }

            return true;

        }
    }
}
