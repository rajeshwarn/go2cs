// Code generated by "stringer -type state"; DO NOT EDIT.

// package template -- go2cs converted at 2020 October 09 05:00:21 UTC
// import "html/template" ==> using template = go.html.template_package
// Original source: C:\Go\src\html\template\state_string.go
using strconv = go.strconv_package;
using static go.builtin;

namespace go {
namespace html
{
    public static partial class template_package
    {
        private static readonly @string _state_name = (@string)"stateTextstateTagstateAttrNamestateAfterNamestateBeforeValuestateHTMLCmtstateRCDATAstateAttrstateURLstateSrcsetstateJSstateJSDqStrstateJSSqStrstateJSRegexpstateJSBlockCmtstateJSLineCmtstateCSSstateCSSDqStrstateCSSSqStrstateCSSDqURLstateCSSSqURLstateCSSURLstateCSSBlockCmtstateCSSLineCmtstateError";



        private static array<ushort> _state_index = new array<ushort>(new ushort[] { 0, 9, 17, 30, 44, 60, 72, 83, 92, 100, 111, 118, 130, 142, 155, 170, 184, 192, 205, 218, 231, 244, 255, 271, 286, 296 });

        private static @string String(this state i)
        {
            if (i >= state(len(_state_index) - 1L))
            {
                return "state(" + strconv.FormatInt(int64(i), 10L) + ")";
            }

            return _state_name[_state_index[i].._state_index[i + 1L]];

        }
    }
}}
