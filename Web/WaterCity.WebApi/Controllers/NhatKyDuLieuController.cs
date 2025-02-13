using Microsoft.AspNetCore.Mvc;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models;
using WaterCity.Core.Models.NhaMay;
using WaterCity.Core.Models.NhatKyDuLieu;
using WaterCity.Service;

namespace WaterCity.WebApi.Controllers
{
    [ApiController]
    public class NhatKyDuLieuController : ControllerBase
    {
        private readonly INhatKyDuLieuService _iNhatKyDuLieuService;

        public NhatKyDuLieuController(INhatKyDuLieuService iNhatKyDuLieuService)
        {
            _iNhatKyDuLieuService = iNhatKyDuLieuService;
        }

        /*[HttpGet]
        [Route(WebApiEndpoint.NhatKyDuLieu.GetAllNhatKyDuLieu)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _iNhatKyDuLieuService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<NhatKyDuLieuEntity>?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.NhatKyDuLieu.GetNhatKyDuLieu)]
        public async Task<IActionResult> GetNhatKyDuLieuById(string keyId)
        {
            var data = await _iNhatKyDuLieuService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(statusCode: StatusCodes.Status400BadRequest, code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsNhatKyDuLieu.NHAT_KY_DU_LIEU_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<NhatKyDuLieuEntity?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: data));
        }*/

        [HttpGet]
        [Route(WebApiEndpoint.NhatKyDuLieu.GetAllNhatKyDuLieu)]
        public IActionResult GetAll()
        {
            var result = _iNhatKyDuLieuService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<NhatKyDuLieuEntity>?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.NhatKyDuLieu.GetNhatKyDuLieu)]
        public IActionResult GetNhatKyDuLieuById(string keyId)
        {
            var data = _iNhatKyDuLieuService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(statusCode: StatusCodes.Status400BadRequest, code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsNhatKyDuLieu.NHAT_KY_DU_LIEU_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<NhatKyDuLieuEntity?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.NhatKyDuLieu.AddNhatKyDuLieu)]
        public async Task<IActionResult> CreateNhatKyDuLieu(NhatKyDuLieuModel nhatKyDuLieuModel)
        {
            try
            {
                var result = await _iNhatKyDuLieuService.CreateAsync(nhatKyDuLieuModel);
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
        [Route(WebApiEndpoint.NhatKyDuLieu.UpdateNhatKyDuLieu)]
        public async Task<IActionResult> UpdateNhatKyDuLieu(string keyId, NhatKyDuLieuModel request)
        {
            try
            {
                await _iNhatKyDuLieuService.UpdateAsync(keyId, request);
                return Ok(new BaseResponseModel<string>(statusCode: StatusCodes.Status202Accepted, code: ResponseCodeConstants.SUCCESS, data: ReponseMessageConstantsNhatKyDuLieu.UPDATE_NHAT_KY_DU_LIEU_SUCCESS));
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
        [Route(WebApiEndpoint.NhatKyDuLieu.DeleteNhatKyDuLieu)]
        public async Task<IActionResult> DeleteNhatKyDuLieu(string keyId)
        {
            try
            {
                await _iNhatKyDuLieuService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(statusCode: StatusCodes.Status202Accepted, code: ResponseCodeConstants.SUCCESS, data: ReponseMessageConstantsNhatKyDuLieu.DELETE_NHAT_KY_DU_LIEU_SUCCESS));
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
