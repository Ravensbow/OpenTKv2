#version 330 core

out vec4 FragColor;
in vec2 texCoord;

uniform sampler2D texture0;
uniform sampler2D texture1;

void main()
{
    vec4 sceneColor = texture2D(texture0, texCoord);
    vec4 addColor = texture2D(texture1, texCoord);   
    FragColor = addColor*addColor.a + sceneColor*(1-addColor.a);
}