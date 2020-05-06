cmake_minimum_required (VERSION 3.17.0)

project( ${NAME} VERSION ${VERSION} LANGUAGES CSharp )

message( STATUS "Generating ${CMAKE_PROJECT_NAME}" )

set(CMAKE_CSharp_FLAGS "/langversion:7")

include(CSharpUtilities)

set(PROJECT_SRC
  main.cs
)

add_executable(${CMAKE_PROJECT_NAME} ${PROJECT_SRC})

add_custom_target(run
    COMMAND ${CMAKE_PROJECT_NAME}
    DEPENDS ${CMAKE_PROJECT_NAME}
    WORKING_DIRECTORY ${CMAKE_PROJECT_DIR}
)

set_property(TARGET ${CMAKE_PROJECT_NAME} PROPERTY VS_DOTNET_TARGET_FRAMEWORK_VERSION "${FRAMEWORK_VERSION}")
set_property(TARGET ${CMAKE_PROJECT_NAME} PROPERTY VS_DOTNET_REFERENCES
    "Microsoft.CSharp"
    "PresentationCore"
    "PresentationFramework"
    "System"
    "System.Core"
    "System.Data"
    "System.Data.DataSetExtensions"
    "WindowsBase"
    "System.Runtime.Serialization"
    "System.ServiceModel")