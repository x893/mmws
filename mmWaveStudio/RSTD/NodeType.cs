using System;

namespace RSTD
{

	public enum NodeType
	{

		UNSUPPORTED,

		ROOT,

		TAB,

		FOLDER,

		FUNCTION,

		ARGUMENT_LIST,

		RETURN_LIST,

		VALUE_TYPE_START = 20,

		REGISTER,

		VAR_TYPE_START = 30,

		VAR,

		MAPPED_VAR,

		FIELD,

		VAR_TYPE_END,

		VALUE_TYPE_END = 40
	}
}
