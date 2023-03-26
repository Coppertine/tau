﻿#define PI 3.14159265359
#define TAU 6.28318530718

layout(location = 0) in highp vec2 v_Position;
layout(location = 1) in highp vec2 v_Colour;

layout(std140, set = 0, binding = 0) uniform m_flashlightParameters {
    highp vec2 centerPos;
    highp float range;
    highp float rotation;
    lowp float flashlightDim;
};

layout(location = 0) out vec4 o_colour;

const mediump float smoothness = 24.0 / 180 * PI;

float atan2(in mediump float y, in mediump float x) {
    return 2 * atan(y / (sqrt(x * x + y * y) + x));
}

float angleDistance(mediump float a, mediump float b) {
    return mod(b - a + PI, TAU) - PI;
}

highp float theta = abs(angleDistance(atan2(v_Position.y - centerPos.y, v_Position.x - centerPos.x), rotation));

bool isInRange(mediump float radi, mediump float sigma) {
    float toCheck = (radi + sigma) / 2;
    return theta <= toCheck;
}

lowp vec4 getColourAt(lowp vec4 originalColour)
{
    if (isInRange(range, 0.0)) {
        return vec4(0.0);
    }
    
    if (isInRange(range, smoothness)) {
        float angleDist = theta;
        angleDist -= range / 2;
        angleDist /= smoothness / 2;
    
        return originalColour * vec4(1.0, 1.0, 1.0, angleDist);
    }
    
    return originalColour * vec4(1.0);
}

void main(void)
{
    o_colour = mix(getColourAt(v_Colour), vec4(0.0, 0.0, 0.0, 1.0), flashlightDim);
}