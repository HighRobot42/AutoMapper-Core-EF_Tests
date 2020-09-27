using AspnetCoreEFCoreExample.DTO;
using AspnetCoreEFCoreExample.Interfaces;
using AspnetCoreEFCoreExample.Models;
using System.Collections.Generic;
using System.Linq;
using AspnetCoreEFCoreExample.DTO.ElementMemberGeneric;

namespace AspnetCoreEFCoreExample.Mapping
{
    public class MainMapping : IHaveCustomMapping
    {
        public MainMapping()
        {
        }

        public void CreateMappings(AutoMapper.Profile cfg)
        {
            //Working ---------------------------
            //cfg.CreateMap<Element, ElementSimpleDto>();

            //Working with Map()
            //cfg.CreateMap<Element, ElementSimpleDto>()
            //    .ForMember(dest => dest.Categories,
            //        opt => opt.MapFrom((src, dest, destMember, resContext)
            //            => dest.Categories
            //                = resContext.Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryBasicInfosDto>>(
            //                    src.Categories.Where(m =>
            //                        m.Id == (int)resContext.Options.Items["CategoryId"]))));
            int? categoryId = null;
            cfg.CreateMap<Category, CategoryMainInfosDto>();
            cfg.CreateMap<Category, CategoryBasicInfosDto>();

            //Working with projection
            cfg.CreateMap<Element, ElementSimpleDto>()
                //.ForMember(c => c.CategoryCount,
                //    opt =>
                //        opt.MapFrom(c => c.Categories.Count))
                .ForMember(c => c.Categories,
                    opt =>
                        //opt.MapFrom((src, dest, destMember, resContext) => src.Categories.Where(c => c.Id == (int)resContext.Options.Items["CategoryId"])));
                        //opt.MapFrom((src, dest, destMember, resContext) => src.Categories.Where(c => c.Id == 1)));
                        opt.MapFrom(src => src.Categories.Where(c => c.Id == categoryId)));

            //Working with projection
            cfg.CreateMap<Element, ElementDto<CategoryBasicInfosDto>>()
                //.ForMember(c => c.CategoryCount,
                //    opt =>
                //        opt.MapFrom(c => c.Categories.Count))
                .ForMember(nameof(Element.Categories),
                    opt =>
                        //opt.MapFrom((src, dest, destMember, resContext) => src.Categories.Where(c => c.Id == (int)resContext.Options.Items["CategoryId"])));
                        //opt.MapFrom((src, dest, destMember, resContext) => src.Categories.Where(c => c.Id == 1)));
                        opt.MapFrom(src => src.Categories.Where(c => c.Id == categoryId)));

            //ElementUser
            cfg.CreateMap<ElementMember, ElementMemberDto<UserBasicInfosDto>>()
                .ForMember(nameof(ElementMemberDto<UserBasicInfosDto>.User), opt =>
                    opt.MapFrom(src => src.User));
            cfg.CreateMap<ElementMember, ElementMemberDto<UserMainInfosDto>>()
                .ForMember(nameof(ElementMemberDto<UserBasicInfosDto>.User), opt =>
                    opt.MapFrom(src => src.User));

            //cfg.CreateMap(typeof(Element), typeof(ElementWithUserDto<UserMainInfosDto>))
            cfg.CreateMap<Element, ElementWithUserDto<UserMainInfosDto>>()
                .ForMember(nameof(ElementWithUserDto<UserMainInfosDto>.ElementUser), opt =>
                    opt.MapFrom(src => src.ElementMembers.FirstOrDefault()));
            //cfg.CreateMap(typeof(Element), typeof(ElementWithUserDto<UserBasicInfosDto>));
            cfg.CreateMap<Element, ElementWithUserDto<UserBasicInfosDto>>()
                .ForMember(nameof(ElementWithUserDto<UserMainInfosDto>.ElementUser), opt =>
                    opt.MapFrom(src => src.ElementMembers.FirstOrDefault()));


            //opt.MapFrom((src, dest, destMember, resContext)
            //=> resContext.Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryBasicInfosDto>>(src.Categories.Where(c => c.Id == (long)categoryId).ToList<Category>())));

            //cfg.CreateMap<Element, ElementSimpleDto>()
            //    .ForMember(c => c.Categories,
            //        opt =>
            //            opt.MapFrom((src, dest, destMember, resContext)
            //                => resContext.Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryBasicInfosDto>>(null)));
            //src.Categories.Where(c => c.Id == (long)categoryId).ToList<Category>()

            //.ForMember(c => c.User,
            //t => t.MapFrom(x => x.ElementMembers.FirstOrDefault().User));

            //cfg.CreateMap(typeof(Element), typeof(ElementDto<>));
            //cfg.CreateMap(typeof(Element), typeof(ElementDto<>))
            //    .ForMember("Categories",
            //        opt => opt.MapFrom((src, dest, destMember, resContext) => resContext.))

            //.ForMember(dest => dest.ElementMember,
            //    opt => opt.MapFrom((src, dest, destMember, resContext) =>
            //        dest.ElementMember
            //            = resContext.Mapper.Map<ElementMember, ElementMemberBasicInfosDto<ProfileBasicInfosDto>>(
            //                src.ElementMembers.FirstOrDefault(m => m.TargetEntityId.Equals((long)resContext.Options.Items["UserId"])))))

            //(src => src.ElementMember
            //        = resContext.Mapper.Map<ElementMember, ElementMemberBasicInfosDto<ProfileBasicInfosDto>>(
            //            src.ElementMembers.FirstOrDefault(m => m.TargetEntityId.Equals((long)resContext.Options.Items["UserId"])))))

            //.ForMember("User", t => t.MapFrom("User"));
            cfg.CreateMap<User, UserBasicInfosDto>();
            cfg.CreateMap<User, UserMainInfosDto>();

        }
    }
}
