﻿layout(location = 0) in highp vec2 m_Position;

void main(void)
{
    gl_Position = g_ProjMatrix * vec4(m_Position.xy, 1.0, 1.0);
}