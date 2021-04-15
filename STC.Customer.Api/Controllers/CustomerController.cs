﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using STC.Customer.Application.Commands.DTOs;
using STC.Customer.Application.Commands.Parameters;
using STC.Customer.Application.Queries.Parameters;
using STC.Customer.Application.Queries.Results;
using STC.Shared.Cqrs.Command;
using STC.Shared.Cqrs.Query;

namespace STC.Customer.Api.Controllers
{
    [ApiController]
    [Route("customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IQueryExecutor _queryExecutor;

        public CustomerController(
            ICommandExecutor commandExecutor,
            IQueryExecutor queryExecutor)
        {
            _commandExecutor = commandExecutor;
            _queryExecutor = queryExecutor;
        }

        [HttpGet]
        [Route("{customerId:guid}")]
        [ProducesResponseType(typeof(GetCustomerQueryResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCustomer(Guid customerId)
        {
            var results = await _queryExecutor.ExecuteAsync<GetCustomerQueryParameters, GetCustomerQueryResult>(
                new GetCustomerQueryParameters(
                    customerId: customerId));

            if (results == null)
            {
                return BadRequest();
            }

            return Ok(results);
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateCustomer([FromBody] CustomerApiParameters parameters)
        {
            await _commandExecutor.ExecuteAsync(
                new CustomerCommandParameters(
                    customerId: parameters.CustomerId,
                    age: parameters.Age));

            return Ok();
        }
    }
}
