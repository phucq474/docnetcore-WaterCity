using Microsoft.AspNetCore.Mvc;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models;
using WaterCity.Core.Models.HopDong;

namespace WaterCity.WebApi.Controllers
{
    [ApiController]
    public class HopDongController : ControllerBase
    {
        private readonly IHopDongService _iHopDongService;

        public HopDongController(IHopDongService iHopDongService)
        {
            _iHopDongService = iHopDongService;
        }

        /*[HttpGet]
        [Route(WebApiEndpoint.HopDong.GetAllHopDong)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _iHopDongService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<HopDongEntity>?>(
                statusCode: StatusCodes.Status200OK, 
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.HopDong.GetHopDong)]
        public async Task<IActionResult> GetHopDongById(string keyId)
        {
            var data = await _iHopDongService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest, 
                    code: ResponseCodeConstants.NOT_FOUND, 
                    message: ReponseMessageConstantsHopDong.HOP_DONG_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<HopDongEntity?>
                    (statusCode: StatusCodes.Status200OK, 
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }*/

        [HttpGet]
        [Route(WebApiEndpoint.HopDong.GetAllHopDong)]
        public IActionResult GetAll()
        {
            var result = _iHopDongService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<HopDongEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.HopDong.GetHopDongByKeyId)]
        public IActionResult GetHopDongByKeyId(string keyId)
        {
            var data = _iHopDongService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsHopDong.HOP_DONG_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<HopDongEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpGet]
        [Route(WebApiEndpoint.HopDong.GetHopDongById)]
        public IActionResult GetHopDongById(string Id)
        {
            var data = _iHopDongService.GetByIdAsync(Id);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsHopDong.HOP_DONG_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<HopDongEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.HopDong.AddHopDong)]
        public async Task<IActionResult> CreateHopDong(HopDongModel model)
        {
            try
            {
                var result = await _iHopDongService.CreateAsync(model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status201Created,
                    code: ResponseCodeConstants.SUCCESS,
                    data: result));
            }
            catch (Exception e)
            {
                dynamic result;
                if (e is CoreException error)
                {
                    result = new BaseResponseModel<string>(
                        statusCode: error.StatusCode,
                        code: error.Code,
                        message: error.Message);
                    return BadRequest(result);
                }
                result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status500InternalServerError,
                    code: ResponseCodeConstants.FAILED,
                    message: e.Message);
                return BadRequest(result);
            }
        }

        [HttpPut]
        [Route(WebApiEndpoint.HopDong.UpdateHopDong)]
        public async Task<IActionResult> UpdateHopDong(string keyId, HopDongModel model)
        {
            try
            {
                await _iHopDongService.UpdateAsync(keyId, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsHopDong.UPDATE_HOP_DONG_SUCCESS));
            }
            catch (Exception e)
            {
                dynamic result;
                if (e is CoreException error)
                {
                    result = new BaseResponseModel<string>(
                        statusCode: error.StatusCode,
                        code: error.Code,
                        message: error.Message);
                    return BadRequest(result);
                }
                result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status500InternalServerError,
                    code: ResponseCodeConstants.FAILED,
                    message: e.Message);
                return BadRequest(result);
            }

        }

        [HttpDelete]
        [Route(WebApiEndpoint.HopDong.DeleteHopDong)]
        public async Task<IActionResult> DeleteHopDong(string keyId)
        {
            try
            {
                await _iHopDongService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsHopDong.DELETE_HOP_DONG_SUCCESS));
            }
            catch (Exception e)
            {
                dynamic result;
                if (e is CoreException error)
                {
                    result = new BaseResponseModel<string>(
                        statusCode: error.StatusCode,
                        code: error.Code,
                        message: error.Message);
                    return BadRequest(result);
                }
                result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status500InternalServerError,
                    code: ResponseCodeConstants.FAILED,
                    message: e.Message);
                return BadRequest(result);
            }
        }
    }
}
