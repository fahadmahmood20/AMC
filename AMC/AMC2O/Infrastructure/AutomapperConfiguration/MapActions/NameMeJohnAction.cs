using AMC2O.Entities;
using AMC2O.Entities.VM;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMC2O.Infrastructure.AutomapperConfiguration.MapActions
{
    public class NameMeJohnActionInterface : NameMeJohnAction<Student, StudentVM>
    {

    }
    public class NameMeJohnAction<T, R> : IMappingAction<T, R>
    {
        public void Process(T source, R destination, ResolutionContext context)
        {
            // do not map properties for refrence entities - otherwise nhibernate will try to update parent object and will give error
            foreach (var propertyMap in context.ConfigurationProvider.GetAllTypeMaps().SelectMany(c => c.PropertyMaps))
            {
                propertyMap.Ignored = true;
            }
        }
    }
    public class RevertNameMeJohnAction : IMappingAction<StudentVM, Student>
    {
        public void Process(StudentVM source, Student destination, ResolutionContext context)
        {
            destination.Name = "Fahad";
        }
    }
}
