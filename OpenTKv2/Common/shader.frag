#version 330 core

out vec4 FragColor;

in vec2 texCoord;
in vec3 surfaceNormal;
in vec3 toLightVector;

uniform sampler2D texture0;
uniform sampler2D texture1;
uniform vec3 lightColor;

void main()
{
    
    vec3 unitNorm= normalize(surfaceNormal);
    vec3 unitLightVector= normalize(toLightVector);

    float nDot1 = dot(unitNorm,unitLightVector);
    float brightness = max(nDot1,0.0);
    vec3 diffuse = brightness * lightColor;
    
    vec4 sceneColor = vec4(diffuse,0.0)*(texture(texture0, texCoord)/texture(texture0, texCoord));
    vec4 addColor = texture(texture1, texCoord);
    
    FragColor = addColor*addColor.a + sceneColor*(1-addColor.a);
    //FragColor = mix(sceneColor,addColor,0.0);
}