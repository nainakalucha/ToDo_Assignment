using Adform_Todo.Common.Contracts;
using Adform_Todo.Common.Dtos;
using Adform_Todo.Common.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Adform_ToDo.API.Controllers.v1
{
    /// <summary>
    /// Labels controller.
    /// </summary>
    [Authorize(Roles = "User,Admin")]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class LabelController : ControllerBase
    {
        private readonly ILabelManager _labelManager;
        private readonly IMapper _mapper;

        public LabelController(ILabelManager labelManager, IMapper mapper)
        {
            _labelManager = labelManager;
            _mapper = mapper;
        }
        /// <summary>
        /// Get all label records.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns> Action result based on Success/Failure.</returns>
        /// <response code="200"> Gets all  Labels. </response>
        /// <response code="404"> Error: 404 not found </response>
        /// <response code="401"> Authorization information is missing or invalid.</response>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType( typeof(RequestResponse<PagedList<LabelDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json", "application/xml", Type = typeof(List<string>))]
        [HttpGet]
        public async Task<IActionResult> GetAllLabels([FromQuery]PaginationParameters parameters)
        {
            long userId = long.Parse(HttpContext.Items["UserId"].ToString());
            PagedList<LabelDto> pagedLabel = await _labelManager.GetAllLabels(parameters, userId);
            if (pagedLabel != null)
            {
                if (pagedLabel.Count > 0)
                {
                    var metadata = new
                    {
                        pagedLabel.TotalCount,
                        pagedLabel.PageSize,
                        pagedLabel.CurrentPage,
                        pagedLabel.TotalPages,
                        pagedLabel.HasNext,
                        pagedLabel.HasPrevious
                    };
                    Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
                    return Ok(
                        new RequestResponse<PagedList<LabelDto>>
                        {
                            IsSuccess = true,
                            Result = pagedLabel,
                            Message = "Items retrieval successful."
                        });
                }
                else
                {
                    return Ok(
                        new RequestResponse<string>
                        {
                            IsSuccess = true,
                            Result = "No Label records present.",
                            Message = " Please add few labels first."
                        });
                }
            }
            return NotFound(
                new RequestResponse<string>
                {
                    IsSuccess = false,
                    Result = "No Results Found.",
                    Message = "No data found."
                });
        }


        /// <summary>
        /// Get label record based on ID.
        /// </summary> 
        /// <param name="id" example="1"></param>
        /// <returns>Returns Action result" type based on Success/Failure.</returns>
        /// <response code="200"> Gets specified label.</response>
        /// <response code="404"> A label with the specified label ID was not found.</response>
        /// <response code="401"> Authorization information is missing or invalid.</response>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(RequestResponse<LabelDto>),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json", "application/xml", Type = typeof(List<string>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLabelById(long id)
        {
            long userId = long.Parse(HttpContext.Items["UserId"].ToString());
            LabelDto LabelModel = await _labelManager.GetLabelById(id, userId);
            if (LabelModel != null)
            {
                return Ok(
                    new RequestResponse<LabelDto>
                    {
                        IsSuccess = true,
                        Result = LabelModel,
                        Message = "Label records retrieved successfully."
                    });
            }
            return NotFound(
                new RequestResponse<string>
                {
                    IsSuccess = false,
                    Result = "Not found.",
                    Message = "No data exist for Id = " + id + "."
                });
        }
        /// <summary>
        /// Create Label record.
        /// </summary>
        /// <param name="createLabelModel"></param>
        /// <param name="version"></param>
        /// <returns>Returns Action result type based on Success/Failure.</returns>
        /// <response code="201"> Creates Label and returns location where it is created.</response>
        /// <response code="400"> Invalid request format.</response>
        /// <response code="401"> Authorization information is missing or invalid.</response>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json", "application/xml", Type = typeof(List<string>))]
        [HttpPost]
        public async Task<IActionResult> CreateLabel(CreateLabelModel createLabelModel, ApiVersion version)
        {
            long userId = long.Parse(HttpContext.Items["UserId"].ToString());
            if (createLabelModel == null || string.IsNullOrEmpty(createLabelModel.Description))
            {
                return BadRequest(new RequestResponse<string>
                {
                    IsSuccess = false,
                    Result = "Fail",
                    Message = "Please enter correct values. The description cannot be empty."
                });
            }
            createLabelModel.CreatedBy = userId;
            CreateLabelDto createLabelDto = _mapper.Map<CreateLabelDto>(createLabelModel);
            LabelDto createdLabel = await _labelManager.AddLabel(createLabelDto);
            if(createdLabel == null)
            {
                return BadRequest(new RequestResponse<string>
                {
                    IsSuccess = false,
                    Result = "Fail",
                    Message = "The Label already exists. Try another one."
                });
            }
            return CreatedAtAction(nameof(GetLabelById), new { createdLabel.LabelId, version = $"{version}" }, createdLabel);
        }

        /// <summary>
        /// Delete specific label record.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns Action result type based on Success/Failure.</returns>
        /// <response code="200"> Deletes specified label record.</response>
        /// <response code="404"> A label with the specified label ID was not found.</response>
        /// <response code="401"> Authorization information is missing or invalid.</response>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(RequestResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json", "application/xml", Type = typeof(List<string>))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLabel(long id)
        {
            long userId = long.Parse(HttpContext.Items["UserId"].ToString());
            int deletedItem = await _labelManager.DeleteLabel(id, userId);
            if (deletedItem == 1)
            {
                return Ok(
                    new RequestResponse<string>
                    {
                        IsSuccess = true,
                        Result = "Deleted successful",
                        Message = "Label with ID = " + id + " is deleted by UserId = " + userId + "."
                    });
            }
            return NotFound(
                new RequestResponse<string>
                {
                    IsSuccess = false,
                    Result = "Not found.",
                    Message = "No data exist for Id = " + id
                });
        }

    }
}