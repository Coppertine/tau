﻿#include "sh_Utils.h"
#include "Internal/sh_MaskingInfo.h"

layout(location = 0) in highp vec2 m_Position;
layout(location = 1) in lowp vec4 m_Colour;
layout(location = 2) in mediump vec2 m_TexCoord;
layout(location = 3) in mediump vec4 m_TexRect;
layout(location = 4) in mediump vec2 m_BlendRange;
layout(location = 6) in int m_MaskingIndex;

layout(location = 0) out highp vec2 v_MaskingPosition;
layout(location = 1) out lowp vec4 v_Colour;
layout(location = 2) out mediump vec2 v_TexCoord;
layout(location = 3) out mediump vec4 v_TexRect;
layout(location = 4) out mediump vec2 v_BlendRange;
layout(location = 5) flat out int v_MaskingIndex;
layout(location = 6) out highp vec2 v_ScissorPosition;
layout(location = 7) out highp vec2 v_Position;


void main(void)
{
	// Transform from screen space to scissor space.
    highp vec4 scissorPos = g_MaskingInfo.ToScissorSpace * vec4(m_Position, 1.0, 0.0);
    v_ScissorPosition = scissorPos.xy / scissorPos.z;

	v_Colour = m_Colour;
	v_TexCoord = m_TexCoord;
	v_TexRect = m_TexRect;
	v_BlendRange = m_BlendRange;
	v_Position = m_Position;
	v_MaskingIndex = m_MaskingIndex;

	gl_Position = g_ProjMatrix * vec4(m_Position, 1.0, 1.0);
}
