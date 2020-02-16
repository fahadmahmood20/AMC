using AMC.MapConfiguration;
using AMC.Models.ConfigElement;
using AMC.Models.InnerCollection;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMC.Models
{
    public class Children : ConfigurationElement, IChildren
    {
        public Children()
        {
        }
        //public Setting(ISetting children)
        //{
        //    Name = "Test";
        //    FatherName = "TestFather";
        //    childrenCollection = new SettingCollection() { DefaultValue = -1, FullName = "Children Name 1", Enabled = false };
        //    if (children != null)
        //    {
        //        //if (flag)
        //        //{
        //        //    /////////////////////////////////////////////////////////////////////
        //        //    ////            Using Generic Mapper Configuration                ///
        //        //    /////////////////////////////////////////////////////////////////////
        //        //    var mapper = ObjectMapperFactory.CreateMapper<ISetting, ISetting>();
        //        //    mapper.Map(children, this);
        //        //}
        //        //else
        //        //{
        //        /////////////////////////////////////////////////////////////////////
        //        ////       Using Profile Registration Mapper Configuration        ///
        //        /////////////////////////////////////////////////////////////////////
        //        var config = new MapperConfiguration(
        //            cfg =>
        //            {
        //                cfg.CreateMap<Setting, Setting>();
        //                cfg.CreateMap<SettingCollection, SettingCollection>()
        //                .AfterMap((src, dst, resolutionContext) =>
        //                {
        //                    //dst.Clear();
        //                    //foreach(var item in src)
        //                    //{
        //                    //    dst.Add(resolutionContext.Mapper.Map<SettingElement>(item));
        //                    //}
        //                });
        //                cfg.CreateMap<SettingElement, SettingElement>();
        //            });
        //        config.AssertConfigurationIsValid();
        //        var mapper = new Mapper(config);
        //        var test = mapper.Map<ISetting, ISetting>(children);
        //        mapper.Map(children, this);

        //        //}
        //    }
        //}
        public static IChildren MapProfile(IChildren children)
        {
            if (children != null)
            {
                var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<Children, Children>();
                    cfg.CreateMap<ChildrenCollection, ChildrenCollection>();
                    cfg.CreateMap<ChildrenConfigElement, ChildrenConfigElement>();
                });
                config.AssertConfigurationIsValid();
                ////var test = AssemblyMappingSetting.CreateMapper(typeof(Children).Assembly);
                var mapper = new Mapper(config);
                return mapper.Map<IChildren, IChildren>(children);
            }
            return children;
        }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public ChildrenCollection childrenCollection { get; set; }
    }
}
