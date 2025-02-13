
using Microsoft.AspNetCore.Mvc;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models;
using WaterCity.Core.Models.NuocSanXuat;

namespace WaterCity.WebApi.Controllers
{
    [ApiController]
    public class NuocSanXuatController : ControllerBase
    {
        private readonly INuocSanXuatService _iNuocSanXuatService;

        public NuocSanXuatController(INuocSanXuatService iNuocSanXuatService)
        {
            _iNuocSanXuatService = iNuocSanXuatService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.NuocSanXuat.GetAllNuocSanXuat)]
        public IActionResult GetAll()
        {
            var result = _iNuocSanXuatService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<NuocSanXuatEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.NuocSanXuat.GetNuocSanXuat)]
        public IActionResult GetNuocSanXuatById(string keyId)
        {
            var data = _iNuocSanXuatService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsNuocSanXuat.NUOCSANXUAT_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<NuocSanXuatEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.NuocSanXuat.AddNuocSanXuat)]
        public async Task<IActionResult> CreateNuocSanXuat(NuocSanXuatModel model)
        {
            try
            {
                var result = await _iNuocSanXuatService.CreateAsync(model);
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
        [Route(WebApiEndpoint.NuocSanXuat.UpdateNuocSanXuat)]
        public async Task<IActionResult> UpdateNuocSanXuat(string keyId, NuocSanXuatModel model)
        {
            try
            {
                await _iNuocSanXuatService.UpdateAsync(keyId, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsNuocSanXuat.UPDATE_NUOCSANXUAT_SUCCESS));
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
        [Route(WebApiEndpoint.NuocSanXuat.DeleteNuocSanXuat)]
        public async Task<IActionResult> DeleteNuocSanXuat(string keyId)
        {
            try
            {
                await _iNuocSanXuatService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsNuocSanXuat.DELETE_NUOCSANXUAT_SUCCESS));
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
