using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Core.DTOs;
using WebApi.Core.Models;
using WebApi.Core.Services;

namespace WebApi.Api.Controllers
{
    public class CommentController : CustomBaseController
    {
        private IMapper _mapper;
        private readonly ICommentService _commentService;
        public CommentController(IMapper mapper, ICommentService commentService)
        {
            _mapper = mapper;
            _commentService = commentService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var comments = await _commentService.GetAllAsync();
            var commentsDto = _mapper.Map<List<CommentDto>>(comments.ToList());
            return CreateActionResult(GlobalResultDto<List<CommentDto>>.Success(200, commentsDto));
        }

        [HttpGet("{id}")]
        //Get api/Team/3
        public async Task<IActionResult> GetById(int id)
        {
            var comment = await _commentService.GetById(id);
            var commentDto = _mapper.Map<CommentDto>(comment);
            return CreateActionResult(GlobalResultDto<CommentDto>.Success(200, commentDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CommentDto commentDto)
        {
            var comment = await _commentService.AddAsync(_mapper.Map<Comment>(commentDto));
            var commentDtos = _mapper.Map<CommentDto>(comment);
            return CreateActionResult(GlobalResultDto<CommentDto>.Success(201, commentDtos));
        }

        [HttpPut]
        public async Task<IActionResult> Update(CommentDto commentDto)
        {
            await _commentService.UpdateAsync(_mapper.Map<Comment>(commentDto));
            return CreateActionResult(GlobalResultDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var comment = await _commentService.GetById(id);
            await _commentService.RemoveAsync(comment);

            return CreateActionResult(GlobalResultDto<NoContentDto>.Success(204));
        }

    }
}

