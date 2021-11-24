using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Yol.API.Extensions;
using System.Threading.Tasks;
using Yol.Data.Models;
using Yol.Services.DTOs;
using Yol.Services.DTOs.NewsDtos;
using Yol.Services.IRepository;

namespace Yol.API.Controllers
{
    [Route("/api/[controller]/[action]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public NewsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost]
        public async Task<IActionResult> CreateNews([FromForm] NewsForCreationDto creationDto)
        {
            var admin = await _unitOfWork.Admins.Get(p => p.Id == creationDto.AdminId);
            if (admin == null)
                return NotFound("Admin doesn't found");
            var news = _mapper.Map<News>(creationDto);
            await _unitOfWork.News.Insert(news);
            await _unitOfWork.Save();
            return Ok(news);
        }

        [HttpGet]
        public async Task<IActionResult> GetNewses([FromForm] RequestParams requestParams)
        {
            if(requestParams.OrderBy is null)
            {
                requestParams.OrderBy = "AdminId";
            }

            var news = await _unitOfWork.News.GetPagedList(requestParams, order => order.OrderBy(requestParams.OrderBy));
            var response = new ResponseDto
            {
                PageCount = news.PageCount,
                Total = news.TotalItemCount,
                Current = news.PageNumber,
                PageSize = news.PageSize,
                HasPreviousPage = news.HasPreviousPage,
                HasNextPage = news.HasNextPage,
                FirstItemOnPage = news.FirstItemOnPage,
                LastItemOnPage = news.LastItemOnPage,
                Data = _mapper.Map<IEnumerable<NewsDTO>>(news)
            };
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetNews(Guid id)
        {
            var news = await _unitOfWork.News.Get(p => p.Id == id);
            if(news is null)
            {
                return NotFound("News doesn't found");
            }
            return Ok(news);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateNews([FromForm] NewsForCreationDto creationDto, Guid id)
        {
            var news = await _unitOfWork.News.Get(p => p.Id == id);
            if (news != null)
                return NotFound("News doesn't found");
            _mapper.Map(creationDto, news);

            _unitOfWork.News.Update(news);
            await _unitOfWork.Save();
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteNews(Guid Id)
        {
            var news = await _unitOfWork.News.Get(p => p.Id == Id);
            if(news is null)
            {
                return NotFound("News doesn't found");
            }
            _unitOfWork.News.Delete(news);
            await _unitOfWork.Save();
            return NoContent();
        }
    }
}
