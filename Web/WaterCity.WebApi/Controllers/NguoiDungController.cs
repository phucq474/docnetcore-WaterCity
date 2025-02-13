using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models.NguoiDung;
using WaterCity.Core.Models;
using WaterCity.Service;

namespace WaterCity.WebApi.Controllers
{
    [ApiController]
    public class NguoiDungController : ControllerBase
    {
        private readonly INguoiDungService _iNguoiDungService;

        public NguoiDungController(INguoiDungService iNguoiDungService)
        {
            _iNguoiDungService = iNguoiDungService;
        }

        /*[HttpGet]
        [Route(WebApiEndpoint.NguoiDung.GetAllNguoiDung)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _iNguoiDungService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<NguoiDungEntity>?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.NguoiDung.GetNguoiDung)]
        public async Task<IActionResult> GetNguoiDungById(string keyId)
        {
            var data = await _iNguoiDungService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(statusCode: StatusCodes.Status400BadRequest, code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsNguoiDung.NGUOI_DUNG_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<NguoiDungEntity?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: data));
        }*/

        [HttpGet]
        [Route(WebApiEndpoint.NguoiDung.GetAllNguoiDung)]
        public IActionResult GetAll()
        {
            var result = _iNguoiDungService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<NguoiDungEntity>?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.NguoiDung.GetNguoiDung)]
        public IActionResult GetNguoiDungById(string keyId)
        {
            var data = _iNguoiDungService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(statusCode: StatusCodes.Status400BadRequest, code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsNguoiDung.NGUOI_DUNG_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<NguoiDungEntity?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.NguoiDung.AddNguoiDung)]
        public async Task<IActionResult> CreateNguoiDung(NguoiDungModel NguoiDung)
        {
            try
            {
                var result = await _iNguoiDungService.CreateAsync(NguoiDung);
                return Ok(new BaseResponseModel<string>(statusCode: StatusCodes.Status201Created, code: ResponseCodeConstants.SUCCESS, data: result));
            }
            catch (Exception e)
            {
                dynamic result;
                if (e is CoreException error)
                {
                    result = new BaseResponseModel<string>(statusCode: error.StatusCode, code: error.Code, message: error.Message);
                    return BadRequest(result);
                }
                result = new BaseResponseModel<string>(statusCode: StatusCodes.Status500InternalServerError, code: ResponseCodeConstants.FAILED, message: e.Message);
                return BadRequest(result);
            }
        }

        [HttpPut]
        [Route(WebApiEndpoint.NguoiDung.UpdateNguoiDung)]
        public async Task<IActionResult> UpdateNguoiDung(string keyId, NguoiDungModel request)
        {
            try
            {
                await _iNguoiDungService.UpdateAsync(keyId, request);
                return Ok(new BaseResponseModel<string>(statusCode: StatusCodes.Status202Accepted, code: ResponseCodeConstants.SUCCESS, data: ReponseMessageConstantsNguoiDung.UPDATE_NGUOI_DUNG_SUCCESS));
            }
            catch (Exception e)
            {
                dynamic result;
                if (e is CoreException error)
                {
                    result = new BaseResponseModel<string>(statusCode: error.StatusCode, code: error.Code, message: error.Message);
                    return BadRequest(result);
                }
                result = new BaseResponseModel<string>(statusCode: StatusCodes.Status500InternalServerError, code: ResponseCodeConstants.FAILED, message: e.Message);
                return BadRequest(result);
            }
        }

        [HttpDelete]
        [Route(WebApiEndpoint.NguoiDung.DeleteNguoiDung)]
        public async Task<IActionResult> DeleteNguoiDung(string keyId)
        {
            try
            {
                await _iNguoiDungService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(statusCode: StatusCodes.Status202Accepted, code: ResponseCodeConstants.SUCCESS, data: ReponseMessageConstantsNguoiDung.DELETE_NGUOI_DUNG_SUCCESS));
            }
            catch (Exception e)
            {
                dynamic result;
                if (e is CoreException error)
                {
                    result = new BaseResponseModel<string>(statusCode: error.StatusCode, code: error.Code, message: error.Message);
                    return BadRequest(result);
                }
                result = new BaseResponseModel<string>(statusCode: StatusCodes.Status500InternalServerError, code: ResponseCodeConstants.FAILED, message: e.Message);
                return BadRequest(result);
            }
        }
    }
}
