﻿using Microsoft.AspNetCore.Mvc;
using Oms.Domain.Requests.Cm;
using Oms.Domain.Services;
using System.Threading.Tasks;

namespace Oms.Api.Controllers
{

    [Route("api/cms")]
    [ApiController]
    public class CmController : ControllerBase
    {
        private readonly ICmService _cmService;

        public CmController(ICmService cmService)
        {
            _cmService = cmService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _cmService.GetCmsAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _cmService.GetCmAsync(new GetCmRequest{ CmsId = id });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddCmRequest request)
        {
            var result = await _cmService.AddCmAsync(request);

            return CreatedAtAction(nameof(GetById), new { id = result.CmsId }, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, EditCmRequest request)
        {
            request.CmsId = id;

            var result = await _cmService.EditCmAsync(request);

            return Ok(result);
        }
    }
}