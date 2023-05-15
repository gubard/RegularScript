using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegularScript.Core.Common.Interfaces;

public interface ITaskCompletionSourceEnumerator : IEnumerator<Task>
{
}