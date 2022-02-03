using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TypeScriptSchemaCompare.Core.Interfaces;
using TypeScriptSchemaCompare.SharedKernal;
using System.Linq;

namespace TypeScriptSchemaCompare.Core
{
    public class CompareValidator: AbstractValidator<CompareRequest> { }
    public class CompareRequest: IRequest<CompareResponse> {
        public string Source { get; set; }
        public string CompareTo { get; set; }
    }
    public class CompareResponse: ResponseBase {
        public string[] Errors { get; set; }
    }
    public class CompareHandler: IRequestHandler<CompareRequest, CompareResponse>
    {    
        public async Task<CompareResponse> Handle(CompareRequest request, CancellationToken cancellationToken)
        {
            var separator = new string[] { "\r\n", "\r", "\n" };

            var sourceParts = request.Source.Split(
                separator,
                StringSplitOptions.None);

            var compareToParts = request.CompareTo.Split(
                separator,
                StringSplitOptions.None);

            var errors = new List<string>();

            foreach (var part in sourceParts.Where(x => !x.StartsWith("export")))
            {
                bool containsPart = false;

                foreach(var otherPart in compareToParts)
                {
                    if(otherPart.Equals(part))
                    {
                        containsPart = true;
                    }
                }

                if(!containsPart)
                {
                    errors.Add(part.Trim());
                }
            }
            return new ()
            {
                Errors = errors.ToArray()
            };
        }
        
    }

}
