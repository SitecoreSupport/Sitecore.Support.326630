using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Commerce.Data.Customers;
using Sitecore.Commerce.Pipelines;
using Sitecore.Commerce.Pipelines.Customers.Common;
using Sitecore.Commerce.Services.Customers;
using Sitecore.Diagnostics;

namespace Sitecore.Support.Commerce.Pipelines.Customers.GetUser
{
  public class GetUserFromSitecore : UserPipelineProcessor
  {
    public GetUserFromSitecore(IUserRepository userRepository) : base(userRepository)
    {
      
    }

    public override void Process(ServicePipelineArgs args)
    {
      Assert.ArgumentNotNull(args, "args");
      Assert.ArgumentNotNull(args.Request, "args.Request");
      Assert.ArgumentNotNull(args.Result, "args.Result");
      Assert.ArgumentCondition(args.Request is GetUserRequest, "args.Request", "args.Request is GetUserRequest");
      Assert.ArgumentCondition(args.Result is GetUserResult, "args.Result", "args.Result is GetUserResult");
      GetUserRequest request = (GetUserRequest)args.Request;
      Assert.IsNotNullOrEmpty(request.UserName, "request.UserName");
      ((GetUserResult)args.Result).CommerceUser = base.UserRepository.Get(request.UserName);
    }

  }
}