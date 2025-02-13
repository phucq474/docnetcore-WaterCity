using Microsoft.AspNetCore.Mvc;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models;
using WaterCity.Core.Models.DoiTuongGia;

namespace WaterCity.WebApi.Controllers
{
    [ApiController]
    public class DoiTuongGiaController : ControllerBase
    {
        private readonly IDoiTuongGiaService _iDoiTuongGiaService;

        public DoiTuongGiaController(IDoiTuongGiaService iDoiTuongGiaService)
        {
            _iDoiTuongGiaService = iDoiTuongGiaService;
        }

        /*[HttpGet]
        [Route(WebApiEndpoint.DoiTuongGia.GetAllDoiTuongGia)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _iDoiTuongGiaService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<DoiTuongGiaEntity>?>(
                statusCode: StatusCodes.Status200OK, 
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.DoiTuongGia.GetDoiTuongGia)]
        public async Task<IActionResult> GetDoiTuongGiaById(string keyId)
        {
            var data = await _iDoiTuongGiaService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest, 
                    code: ResponseCodeConstants.NOT_FOUND, 
                    message: ReponseMessageConstantsDoiTuongGia.DOI_TUONG_GIA_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<DoiTuongGiaEntity?>
                    (statusCode: StatusCodes.Status200OK, 
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }*/

        [HttpGet]
        [Route(WebApiEndpoint.DoiTuongGia.GetAllDoiTuongGia)]
        public IActionResult GetAll()
        {
            var result = _iDoiTuongGiaService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<DoiTuongGiaEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.DoiTuongGia.GetDoiTuongGia)]
        public IActionResult GetDoiTuongGiaById(string keyId)
        {
            var data = _iDoiTuongGiaService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsDoiTuongGia.DOI_TUONG_GIA_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<DoiTuongGiaEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.DoiTuongGia.AddDoiTuongGia)]
        public async Task<IActionResult> CreateDoiTuongGia(DoiTuongGiaModel model)
        {
            try
            {
                var result = await _iDoiTuongGiaService.CreateAsync(model);
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
        [Route(WebApiEndpoint.DoiTuongGia.UpdateDoiTuongGia)]
        public async Task<IActionResult> UpdateDoiTuongGia(string keyId, DoiTuongGiaModel request)
        {
            try
            {
                await _iDoiTuongGiaService.UpdateAsync(keyId, request);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsDoiTuongGia.UPDATE_DOI_TUONG_GIA_SUCCESS));
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
        [Route(WebApiEndpoint.DoiTuongGia.DeleteDoiTuongGia)]
        public async Task<IActionResult> DeleteDoiTuongGia(string keyId)
        {
            try
            {
                await _iDoiTuongGiaService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsDoiTuongGia.DELETE_DOI_TUONG_GIA_SUCCESS));
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
