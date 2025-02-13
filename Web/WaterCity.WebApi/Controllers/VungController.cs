#region VungCu
/*using Microsoft.AspNetCore.Mvc;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Models;
using WaterCity.Core.Models.Vung;

namespace WaterCity.WebApi.Controllers
{
    [ApiController]
    public class VungController : ControllerBase
    {
        private readonly IVungService _iVungService;

        public VungController(IVungService iVungService)
        {
            _iVungService = iVungService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.Vung.GetAllVung)]
        public IActionResult GetAll()
        {
            var result = _iVungService.GetAllVung();
            return Ok(new BaseResponseModel<ICollection<VungModel>?>
                      (statusCode: StatusCodes.Status200OK,
                       code: ResponseCodeConstants.SUCCESS,
                       data: result));
        }

        [HttpGet()]
        [Route(WebApiEndpoint.Vung.GetVung)]
        public IActionResult GetVungById(string id)
        {
            var data = _iVungService.GetVungById(id);
            if (data == null)
            {
                var result = new BaseResponseModel<string>
                    (statusCode: StatusCodes.Status400BadRequest,
                     code: ResponseCodeConstants.NOT_FOUND,
                     message: ReponseMessageConstants.VUNG_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<VungEntity?>
                       (statusCode: StatusCodes.Status200OK,
                        code: ResponseCodeConstants.SUCCESS,
                        data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.Vung.AddVung)]
        public async Task<IActionResult> CreateVung(VungModel request)
        {
            
            var result = await _iVungService.CreateVungAsync(request);
            return Ok(new BaseResponseModel<string>
                    (statusCode: StatusCodes.Status200OK,
                     code: ResponseCodeConstants.SUCCESS,
                     data: result));
        }

        [HttpPost()]
        [Route(WebApiEndpoint.Vung.UpdateVung)]
        public IActionResult UpdateVung(VungModel request)
        {
            try
            {
                var checkVung = _iVungService.GetVungById(request.Id);
                if (checkVung == null)
                {
                    return BadRequest(new BaseResponseModel<string>
                        (statusCode: StatusCodes.Status404NotFound,
                         code: ResponseCodeConstants.NOT_FOUND,
                         data: ReponseMessageConstants.VUNG_NOT_FOUND));
                }
                var result = _iVungService.UpdateVung(request);
                return Ok(new BaseResponseModel<string>
                    (statusCode: StatusCodes.Status200OK,
                     code: ResponseCodeConstants.SUCCESS,
                     data: ReponseMessageConstants.UPDATE_VUNG_SUCCESS));

            }
            catch (Exception ex)
            {
                var result = new BaseResponseModel<string>
                     (statusCode: StatusCodes.Status400BadRequest,
                      code: ResponseCodeConstants.FAILED,
                      message: ex.Message);
                return BadRequest(result);
            }
        }

        [HttpPost()]
        [Route(WebApiEndpoint.Vung.DeleteVung)]
        public IActionResult DeleteVung(string id)
        {
            try
            {
                var checkVung = _iVungService.GetVungById(id);
                if (checkVung == null)
                {
                    return BadRequest(new BaseResponseModel<string>
                        (statusCode: StatusCodes.Status404NotFound,
                         code: ResponseCodeConstants.NOT_FOUND,
                         data: ReponseMessageConstants.VUNG_NOT_FOUND));
                }
                var result = _iVungService.DeleteVung(id);
                return Ok(new BaseResponseModel<string>
                    (statusCode: StatusCodes.Status200OK,
                     code: ResponseCodeConstants.SUCCESS,
                     data: ReponseMessageConstants.DELETE_VUNG_SUCCESS));

            }
            catch (Exception ex)
            {
                var result = new BaseResponseModel<string>
                      (statusCode: StatusCodes.Status400BadRequest,
                       code: ResponseCodeConstants.FAILED,
                       message: ex.Message);
                return BadRequest(result);
            }
        }
    }
}
*/

#endregion

using Microsoft.AspNetCore.Mvc;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models;
using WaterCity.Core.Models.Vung;

namespace WaterCity.WebApi.Controllers
{
    [ApiController]
    public class VungController : ControllerBase
    {
        private readonly IVungService _iVungService;

        public VungController(IVungService iVungService)
        {
            _iVungService = iVungService;
        }

        /*[HttpGet]
        [Route(WebApiEndpoint.Vung.GetAllVung)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _iVungService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<VungEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.Vung.GetVung)]
        public async Task<IActionResult> GetVungById(string keyId)
        {
            var data = await _iVungService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsVung.VUNG_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<VungEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }*/

        [HttpGet]
        [Route(WebApiEndpoint.Vung.GetAllVung)]
        public IActionResult GetAll()
        {
            var result = _iVungService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<VungEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.Vung.GetVung)]
        public IActionResult GetVungById(string keyId)
        {
            var data = _iVungService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsVung.VUNG_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<VungEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.Vung.AddVung)]
        public async Task<IActionResult> CreateVung(VungModel model)
        {
            try
            {
                var result = await _iVungService.CreateAsync(model);
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
        [Route(WebApiEndpoint.Vung.UpdateVung)]
        public async Task<IActionResult> UpdateVung(string keyId, VungModel model)
        {
            try
            {
                await _iVungService.UpdateAsync(keyId, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsVung.UPDATE_VUNG_SUCCESS));
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
        [Route(WebApiEndpoint.Vung.DeleteVung)]
        public async Task<IActionResult> DeleteVung(string keyId)
        {
            try
            {
                await _iVungService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsVung.DELETE_VUNG_SUCCESS));
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
