using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yol.API.Extensions;
using Yol.Data.Models;
using Yol.Services.DTOs;
using Yol.Services.DTOs.RoadDtos;
using Yol.Services.IRepository;

namespace Yol.API.Controllers
{
    [Route("/api/[controller]/[action]")]
    [ApiController]
    public class RoadController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RoadController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost]
        public async Task<IActionResult> CreateApplication([FromBody] RoadForCreationDTO creationDto)
        {
            var road = _mapper.Map<Road>(creationDto);
            foreach(var coodrinates in creationDto.Cordinates)
            {
                Coordinate coordinate = new Coordinate() { RoadId = road.Id, Id = Guid.NewGuid() };
                await _unitOfWork.Coordinates.Insert(coordinate);
                foreach(var value in coodrinates)
                {
                    CoordinateValue coordinateValue = new CoordinateValue() { CoordinateId = coordinate.Id, Value = value, Id = Guid.NewGuid() };
                    await _unitOfWork.Values.Insert(coordinateValue);
                }
            }
            if(creationDto.Images != null)
                foreach(var image in creationDto.Images)
                {
                    Image image1 = new Image() { Id = Guid.NewGuid(), RoadId = road.Id, FileName = await _unitOfWork.SaveFileAsync(image)};
                    await _unitOfWork.Images.Insert(image1);
                }
            
            
            
            await _unitOfWork.Roads.Insert(road);
            await _unitOfWork.Save();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetRoads([FromForm] RequestParams requestParams)
        {
            if (requestParams.OrderBy is null)
            {
                requestParams.OrderBy = "StartedAt";
            }
            var roads = await _unitOfWork.Roads.GetPagedList(requestParams, order => order.OrderBy(requestParams.OrderBy), 
                new List<string>() { "Admin", "Company" });
            var response = new ResponseDto
            {
                PageCount = roads.PageCount,
                Total = roads.TotalItemCount,
                Current = roads.PageNumber,
                PageSize = roads.PageSize,
                HasPreviousPage = roads.HasPreviousPage,
                HasNextPage = roads.HasNextPage,
                FirstItemOnPage = roads.FirstItemOnPage,
                LastItemOnPage = roads.LastItemOnPage,
                Data = _mapper.Map<IEnumerable<RoadDTO>>(roads)
            };
            return Ok(response);
        }
    }
}
