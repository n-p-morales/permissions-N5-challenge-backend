using System;
namespace permissions_n5_challenge.Domain.Commons.Rules
{
	public interface IRule
	{
        string Message { get; }

        bool IsValid();
    }
}

