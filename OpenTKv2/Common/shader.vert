#version 330 core

layout(location=0) in vec3 aPosition;
layout(location = 1) in vec2 aTexCoord;
layout(location = 2) in vec3 aNormCoord;

out vec2 texCoord;
out vec3 surfaceNormal;
out vec3 toLightVector;


uniform mat4 transform;
uniform mat4 view;
uniform mat4 perspecive;
uniform vec3 lightPosition;

void main()
{
	vec4 worldPossition = vec4(aPosition,0.0)*transform;
	texCoord = aTexCoord;
	gl_Position = vec4(aPosition, 1.0) * transform * view * perspecive;

	surfaceNormal = (transform * vec4(aNormCoord,0.0)).xyz;
	toLightVector = lightPosition - worldPossition.xyz;

}