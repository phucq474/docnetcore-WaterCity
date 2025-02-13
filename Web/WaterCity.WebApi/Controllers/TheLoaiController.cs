using Microsoft.AspNetCore.Mvc;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models;
using WaterCity.Core.Models.TheLoai;

namespace WaterCity.WebApi.Controllers
{
    [ApiController]
    public class TheLoaiController : ControllerBase
    {
        private readonly ITheLoaiService _iTheLoaiService;

        public TheLoaiController(ITheLoaiService iTheLoaiService)
        {
            _iTheLoaiService = iTheLoaiService;
        }

        /*[HttpGet]
        [Route(WebApiEndpoint.TheLoai.GetAllTheLoai)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _iTheLoaiService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<TheLoaiEntity>?>(
                statusCode: StatusCodes.Status200OK, 
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.TheLoai.GetTheLoai)]
        public async Task<IActionResult> GetTheLoaiById(string keyId)
        {
            var data = await _iTheLoaiService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                return BadRequest(data);
            }

            return Ok(new BaseResponseModel<TheLoaiEntity?>
                    (statusCode: StatusCodes.Status200OK, 
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }*/

        [HttpGet]
        [Route(WebApiEndpoint.TheLoai.GetAllTheLoai)]
        public IActionResult GetAll()
        {
            var result = _iTheLoaiService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<TheLoaiEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.TheLoai.GetTheLoai)]
        public IActionResult GetTheLoaiById(string keyId)
        {
            var data = _iTheLoaiService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                return BadRequest(data);
            }

            return Ok(new BaseResponseModel<TheLoaiEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.TheLoai.AddTheLoai)]
        public async Task<IActionResult> CreateTheLoai(TheLoaiModel model)
        {
            try
            {
                var result = await _iTheLoaiService.CreateAsync(model);
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
        [Route(WebApiEndpoint.TheLoai.UpdateTheLoai)]
        public async Task<IActionResult> UpdateTheLoai(string keyId, TheLoaiModel model)
        {
            try
            {
                await _iTheLoaiService.UpdateAsync(keyId, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsTheLoai.UPDATE_THELOAI_SUCCESS));
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
        [Route(WebApiEndpoint.TheLoai.DeleteTheLoai)]
        public async Task<IActionResult> DeleteTheLoai(string keyId)
        {
            try
            {
                await _iTheLoaiService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsTheLoai.DELETE_THELOAI_SUCCESS));
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
