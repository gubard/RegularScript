using RegularScript.Core.Common.Models;

namespace RegularScript.Core.DependencyInjection.Models;

public readonly record struct AutoInjectMemberIdentifier(
    TypeInformation Type,
    AutoInjectMember Member
);