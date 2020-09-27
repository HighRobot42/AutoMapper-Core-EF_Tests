using AspnetCoreEFCoreExample.DTO;
using AspnetCoreEFCoreExample.DTO.ElementMemberGeneric;
using AspnetCoreEFCoreExample.Models;
using AspnetCoreEFCoreExample.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;

namespace AspnetCoreEFCoreExample.Controllers
{
    [Route("api/[controller]")]
    public class MyModelController : Controller
    {
        private readonly IExampleRepository _exampleRepository;
        private readonly DataBaseContext _dbContext;
        private readonly IMapper _mapper;

        public MyModelController(IExampleRepository exampleRepository, DataBaseContext dbContext, IMapper mapper)
        {
            _exampleRepository = exampleRepository;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        // GET: api/mymodel
        [HttpGet("", Name = "GetAll")]
        public IActionResult Get()
        {
            try
            {
                //var linq = _dbContext.Element.Include(c => c.Categories);
                //return Ok(_dbContext.Element.AsQueryable().ProjectTo<ElementDto<CategoryMainInfosDto>>(Mapper.Configuration));
                // var projects = _dbContext.Element.Include(c => c.Categories).AsNoTracking().ProjectTo<ElementSimpleDto>(_mapper.ConfigurationProvider);
                //var map = _mapper.Map<IEnumerable<Element>, IEnumerable<ElementSimpleDto>>(_dbContext.Element.Include(c => c.Categories).AsEnumerable());
                //var projectionWithParam = _dbContext.Element.Include(c => c.Categories)
                //    .ProjectTo<ElementSimpleDto>(_mapper.ConfigurationProvider,
                //        new Dictionary<string, object> {{ "CategoryId", 1}});
                //var projectionWithParam =
                //    _mapper.Map<Element, ElementSimpleDto>(_dbContext.Element.Include(c => c.Categories).FirstOrDefault(t => t.Id == 1),
                //        opt => { opt.Items["CategoryId"] = 1; });

                //_mapper.ConfigurationProvider.BuildExecutionPlan(typeof(Element), typeof(ElementSimpleDto));
                //var expression = _dbContext.Element
                //    //.ProjectTo<ElementSimpleDto>(_mapper.ConfigurationProvider, new Dictionary<string, object> { { "categoryId", 1 } });
                //    .ProjectTo<ElementSimpleDto>().Expression;

                //Working -> It takes desired fields + join
                List<ElementWithUserDto<UserBasicInfosDto>> projectionWithParamListAndSubGeneric = _dbContext.Element
                    //.ProjectTo<ElementSimpleDto>(_mapper.ConfigurationProvider, new Dictionary<string, object> { { "categoryId", 1 } });
                    .ProjectTo<ElementWithUserDto<UserBasicInfosDto>>(_mapper.ConfigurationProvider).ToList();
                //.ProjectTo<ElementSimpleDto>(_mapper.ConfigurationProvider, new Dictionary<string, object> { { "CategoryId", 1 } }).ToList();

                //Working -> It takes desired fields + join
                List<ElementSimpleDto> projectionWithParamList = _dbContext.Element
                    //.ProjectTo<ElementSimpleDto>(_mapper.ConfigurationProvider, new Dictionary<string, object> { { "categoryId", 1 } });
                    .ProjectTo<ElementSimpleDto>(_mapper.ConfigurationProvider, new { categoryId = 1 }).ToList();
                //.ProjectTo<ElementSimpleDto>(_mapper.ConfigurationProvider, new Dictionary<string, object> { { "CategoryId", 1 } }).ToList();

                //Working -> It takes desired fields + join
                List<ElementDto<CategoryBasicInfosDto>> projectionWithParamListGeneric = _dbContext.Element
                    //.ProjectTo<ElementSimpleDto>(_mapper.ConfigurationProvider, new Dictionary<string, object> { { "categoryId", 1 } });
                    .ProjectTo<ElementDto<CategoryBasicInfosDto>>(_mapper.ConfigurationProvider, new { categoryId = 1 }).ToList();
                //.ProjectTo<ElementSimpleDto>(_mapper.ConfigurationProvider, new Dictionary<string, object> { { "CategoryId", 1 } }).ToList();

                //Working => It takes undesired fields but Include a join(which is the expected sql)--------------
                var mappingWithParamList =
                    _mapper.Map<IEnumerable<Element>, IEnumerable<ElementSimpleDto>>(
                        _dbContext.Element.Include(c => c.Categories).Where(t => t.Id != 3).AsEnumerable(),
                        opt => { opt.Items["CategoryId"] = 1; });


                //var genericProjection = _dbContext.Element.Include(c => c.Categories)
                //    .ProjectTo<ElementDto<CategoryBasicInfosDto>>(_mapper.ConfigurationProvider);
                return Ok(projectionWithParamList);
            }
            catch (Exception exception)
            {
                //logg exception or do anything with it
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetSingle")]
        public IActionResult Get(int id)
        {
            try
            {
                Element myModel = _dbContext.Element.FirstOrDefault();

                if (myModel == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<ElementDto<CategoryMainInfosDto>>(myModel));
            }
            catch (Exception exception)
            {
                //Do something with the exception
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        //// POST api/values
        //[HttpPost]
        //public IActionResult Post([FromBody]MyModelViewModel viewModel)
        //{
        //    try
        //    {
        //        if (viewModel == null)
        //        {
        //            return BadRequest();
        //        }

        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        MyModel item = Mapper.Map<MyModel>(viewModel);

        //        _exampleRepository.Add(item);
        //        int save = _exampleRepository.Save();

        //        if (save > 0)
        //        {
        //            return CreatedAtRoute("GetSingle", new { controller = "MyModel", id = item.Id }, item);
        //        }

        //        return BadRequest();
        //    }
        //    catch (Exception exception)
        //    {
        //        //Do something with the exception
        //        return StatusCode((int)HttpStatusCode.InternalServerError);
        //    }
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody]MyModelViewModel viewModel)
        //{
        //    try
        //    {
        //        if (viewModel == null)
        //        {
        //            return BadRequest();
        //        }

        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        MyModel singleById = _exampleRepository.GetSingle(id);

        //        if (singleById == null)
        //        {
        //            return NotFound();
        //        }

        //        singleById.Name = viewModel.Name;

        //        _exampleRepository.Update(singleById);
        //        int save = _exampleRepository.Save();

        //        if (save > 0)
        //        {
        //            return Ok(Mapper.Map<MyModelViewModel>(singleById));
        //        }

        //        return BadRequest();
        //    }
        //    catch (Exception exception)
        //    {
        //        //Do something with the exception
        //        return StatusCode((int)HttpStatusCode.InternalServerError);
        //    }
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    try
        //    {
        //        MyModel singleById = _exampleRepository.GetSingle(id);

        //        if (singleById == null)
        //        {
        //            return NotFound();
        //        }

        //        _exampleRepository.Delete(singleById);
        //        int save = _exampleRepository.Save();

        //        if (save > 0)
        //        {
        //            return NoContent();
        //        }

        //        return BadRequest();
        //    }
        //    catch (Exception exception)
        //    {
        //        //Do something with the exception
        //        return StatusCode((int)HttpStatusCode.InternalServerError);
        //    }
        //}
    }
}
