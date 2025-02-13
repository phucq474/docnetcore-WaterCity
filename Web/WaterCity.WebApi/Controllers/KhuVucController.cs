using Microsoft.AspNetCore.Mvc;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models.KhuVuc;
using WaterCity.Core.Models;
using WaterCity.Contract.Service;

namespace WaterCity.WebApi.Controllers
{
    [ApiController]
    public class KhuVucController : ControllerBase
    {
        private readonly IKhuVucService _iKhuVucService;

        public KhuVucController(IKhuVucService iKhuVucService)
        {
            _iKhuVucService = iKhuVucService;
        }

        /*[HttpGet]
        [Route(WebApiEndpoint.KhuVuc.GetAllKhuVuc)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _iKhuVucService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<KhuVucEntity>?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.KhuVuc.GetKhuVuc)]
        public async Task<IActionResult> GetKhuVucById(string keyId)
        {
            var data = await _iKhuVucService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(statusCode: StatusCodes.Status400BadRequest, code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsKhuVuc.KHU_VUC_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<KhuVucEntity?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: data));
        }*/

        [HttpGet]
        [Route(WebApiEndpoint.KhuVuc.GetAllKhuVuc)]
        public IActionResult GetAll()
        {
            var result = _iKhuVucService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<KhuVucEntity>?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.KhuVuc.GetKhuVuc)]
        public IActionResult GetKhuVucById(string keyId)
        {
            var data = _iKhuVucService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(statusCode: StatusCodes.Status400BadRequest, code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsKhuVuc.KHU_VUC_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<KhuVucEntity?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.KhuVuc.AddKhuVuc)]
        public async Task<IActionResult> CreateKhuVuc(KhuVucModel KhuVuc)
        {
            try
            {
                var result = await _iKhuVucService.CreateAsync(KhuVuc);
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
        [Route(WebApiEndpoint.KhuVuc.UpdateKhuVuc)]
        public async Task<IActionResult> UpdateKhuVuc(string keyId, KhuVucModel request)
        {
            try
            {
                await _iKhuVucService.UpdateAsync(keyId, request);
                return Ok(new BaseResponseModel<string>(statusCode: StatusCodes.Status202Accepted, code: ResponseCodeConstants.SUCCESS, data: ReponseMessageConstantsKhuVuc.UPDATE_KHU_VUC_SUCCESS));
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
        [Route(WebApiEndpoint.KhuVuc.DeleteKhuVuc)]
        public async Task<IActionResult> DeleteKhuVuc(string keyId)
        {
            try
            {
                await _iKhuVucService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(statusCode: StatusCodes.Status202Accepted, code: ResponseCodeConstants.SUCCESS, data: ReponseMessageConstantsKhuVuc.DELETE_KHU_VUC_SUCCESS));
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
