using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using UndertaleModLib;
using UndertaleModLib.Models;
using UndertaleModLib.Scripting;

namespace UndertaleModTool
{
    //Make new deep copy helper functions
    public partial class MainWindow : Window, INotifyPropertyChanged, IScriptInterface
    {
        public UndertaleObject DeepCopy(UndertaleObject obj)
        {
            obj = System.ObjectExtensions.Copy(obj);
            if (obj is UndertaleAnimationCurve)
            {
                ((UndertaleAnimationCurve)obj).Name = Data.Strings.MakeString(((UndertaleAnimationCurve)obj).Name.Content);
                foreach (UndertaleAnimationCurve.Channel chan in ((UndertaleAnimationCurve)obj).Channels)
                    chan.Name = Data.Strings.MakeString(chan.Name.Content);
                return obj;
            }
            else if (obj is UndertaleAudioGroup)
            {
                ((UndertaleAudioGroup)obj).Name = Data.Strings.MakeString(((UndertaleAudioGroup)obj).Name.Content);
                return obj;
            }
            else if (obj is UndertaleBackground)
            {
                ((UndertaleBackground)obj).Name = Data.Strings.MakeString(((UndertaleBackground)obj).Name.Content);
                return obj;
            }
            else if (obj is UndertaleCode)
            {
                ((UndertaleCode)obj).Name = Data.Strings.MakeString(((UndertaleCode)obj).Name.Content);
                return obj;
            }
            else if (obj is UndertaleCodeLocals)
            {
                ((UndertaleCodeLocals)obj).Name = Data.Strings.MakeString(((UndertaleCodeLocals)obj).Name.Content);
                foreach (UndertaleCodeLocals.LocalVar locvar in ((UndertaleCodeLocals)obj).Locals)
                    locvar.Name = Data.Strings.MakeString(locvar.Name.Content);
                return obj;
            }
            else if (obj is UndertaleEmbeddedImage)
            {
                return obj;
            }
            else if (obj is UndertaleEmbeddedAudio)
            {
                return obj;
            }
            else if (obj is UndertaleEmbeddedTexture)
            {
                return obj;
            }
            else if (obj is UndertaleExtension)
            {
                ((UndertaleExtension)obj).Name = Data.Strings.MakeString(((UndertaleExtension)obj).Name.Content);
                ((UndertaleExtension)obj).FolderName = Data.Strings.MakeString(((UndertaleExtension)obj).FolderName.Content);
                ((UndertaleExtension)obj).Name = Data.Strings.MakeString(((UndertaleExtension)obj).Name.Content);
                ((UndertaleExtension)obj).ClassName = Data.Strings.MakeString(((UndertaleExtension)obj).ClassName.Content);
                foreach (UndertaleExtensionFile exFile in ((UndertaleExtension)obj).Files)
                {
                    exFile.Filename = Data.Strings.MakeString(exFile.Filename.Content);
                    exFile.CleanupScript = Data.Strings.MakeString(exFile.CleanupScript.Content);
                    exFile.InitScript = Data.Strings.MakeString(exFile.InitScript.Content);
                    foreach (UndertaleExtensionFunction exFunc in exFile.Functions)
                    {
                        exFunc.Name = Data.Strings.MakeString(exFunc.Name.Content);
                        exFunc.ExtName = Data.Strings.MakeString(exFunc.ExtName.Content);
                    }
                }
                return obj;
            }
            else if (obj is UndertaleFont)
            {
                ((UndertaleFont)obj).Name = Data.Strings.MakeString(((UndertaleFont)obj).Name.Content);
                ((UndertaleFont)obj).DisplayName = Data.Strings.MakeString(((UndertaleFont)obj).DisplayName.Content);
                return obj;
            }
            else if (obj is UndertaleFunction)
            {
                ((UndertaleFunction)obj).Name = Data.Strings.MakeString(((UndertaleFunction)obj).Name.Content);
                return obj;
            }
            else if (obj is UndertaleGameObject)
            {
                ((UndertaleGameObject)obj).Name = Data.Strings.MakeString(((UndertaleGameObject)obj).Name.Content);
                try
                {
                    for (var i = 0; i < ((UndertaleGameObject)obj).Events.Count; i++)
                    {
                        foreach (UndertaleGameObject.Event evnt in ((UndertaleGameObject)obj).Events[i])
                        {
                            foreach (UndertaleGameObject.EventAction action in evnt.Actions)
                            {
                                action.ActionName = Data.Strings.MakeString(action.ActionName?.Content);
                            }
                        }
                    }
                }
                catch
                {
                    // Something went wrong, but probably because it's trying to check something non-existent
                    // Just keep going
                }
                return obj;
            }
            else if (obj is UndertaleGeneralInfo)
            {
                ((UndertaleGeneralInfo)obj).Filename = Data.Strings.MakeString(((UndertaleGeneralInfo)obj).Filename.Content);
                ((UndertaleGeneralInfo)obj).Config = Data.Strings.MakeString(((UndertaleGeneralInfo)obj).Config.Content);
                ((UndertaleGeneralInfo)obj).Name = Data.Strings.MakeString(((UndertaleGeneralInfo)obj).Name.Content);
                ((UndertaleGeneralInfo)obj).DisplayName = Data.Strings.MakeString(((UndertaleGeneralInfo)obj).DisplayName.Content);
                return obj;
            }
            else if (obj is UndertaleLanguage)
            {
                for (var i = 0; i < ((UndertaleLanguage)obj).EntryIDs.Count; i++)
                {
                    ((UndertaleLanguage)obj).EntryIDs[i] = Data.Strings.MakeString(((UndertaleLanguage)obj).EntryIDs[i].Content);
                }
                for (var i = 0; i < ((UndertaleLanguage)obj).Languages.Count; i++)
                {
                    ((UndertaleLanguage)obj).Languages[i].Name = Data.Strings.MakeString(((UndertaleLanguage)obj).Languages[i].Name.Content);
                    ((UndertaleLanguage)obj).Languages[i].Region = Data.Strings.MakeString(((UndertaleLanguage)obj).Languages[i].Region.Content);
                }
                return obj;
            }
            else if (obj is UndertaleOptions)
            {
                foreach (UndertaleOptions.Constant constant in ((UndertaleOptions)obj).Constants)
                {
                    constant.Name = Data.Strings.MakeString(constant.Name.Content);
                    constant.Value = Data.Strings.MakeString(constant.Value.Content);
                }
                return obj;
            }
            else if (obj is UndertalePath)
            {
                ((UndertalePath)obj).Name = Data.Strings.MakeString(((UndertalePath)obj).Name.Content);
                return obj;
            }
            else if (obj is UndertaleRoom)
            {
                ((UndertaleRoom)obj).Name = Data.Strings.MakeString(((UndertaleRoom)obj).Name.Content);
                if (((UndertaleRoom)obj).Caption != null)
                    ((UndertaleRoom)obj).Caption = Data.Strings.MakeString(((UndertaleRoom)obj).Caption.Content);
                for (var i = 0; i < ((UndertaleRoom)obj).Layers.Count; i++)
                {
                    ((UndertaleRoom)obj).Layers[i].LayerName = Data.Strings.MakeString(((UndertaleRoom)obj).Layers[i].LayerName.Content);
                    if (((UndertaleRoom)obj).Layers[i].AssetsData != null)
                    {
                        for (var j = 0; j < ((UndertaleRoom)obj).Layers[i].AssetsData.Sprites.Count; j++)
                        {
                            ((UndertaleRoom)obj).Layers[i].AssetsData.Sprites[j].Name = Data.Strings.MakeString(((UndertaleRoom)obj).Layers[i].AssetsData.Sprites[j].Name.Content);
                        }
                        for (var j = 0; j < ((UndertaleRoom)obj).Layers[i].AssetsData.Sequences.Count; j++)
                        {
                            ((UndertaleRoom)obj).Layers[i].AssetsData.Sequences[j].Name = Data.Strings.MakeString(((UndertaleRoom)obj).Layers[i].AssetsData.Sequences[j].Name.Content);
                        }
                        for (var j = 0; j < ((UndertaleRoom)obj).Layers[i].AssetsData.NineSlices.Count; j++)
                        {
                            ((UndertaleRoom)obj).Layers[i].AssetsData.NineSlices[j].Name = Data.Strings.MakeString(((UndertaleRoom)obj).Layers[i].AssetsData.NineSlices[j].Name.Content);
                        }
                    }
                }
                return obj;
            }
            else if (obj is UndertaleScript)
            {
                ((UndertaleScript)obj).Name = Data.Strings.MakeString(((UndertaleScript)obj).Name.Content);
                return obj;
            }
            else if (obj is UndertaleSequence)
            {
                (obj as UndertaleSequence).Name = Data.Strings.MakeString(((UndertaleSequence)obj).Name.Content);
                for (var i = 0; i < ((UndertaleSequence)obj).Moments.Count; i++)
                {
                    for (var j = 0; j < ((UndertaleSequence)obj).Moments[i].Channels.Count; j++)
                    {
                        ((UndertaleSequence)obj).Moments[i].Channels[j].Event = Data.Strings.MakeString(((UndertaleSequence)obj).Moments[i].Channels[j].Event.Content);
                    }
                }
                for (var i = 0; i < ((UndertaleSequence)obj).Tracks.Count; i++)
                {
                    ((UndertaleSequence)obj).Tracks[i] = RecurseTracks(((UndertaleSequence)obj).Tracks[i]);
                }
                return obj;
            }
            else if (obj is UndertaleShader)
            {
                ((UndertaleShader)obj).Name = Data.Strings.MakeString(((UndertaleShader)obj).Name.Content);
                ((UndertaleShader)obj).GLSL_ES_Fragment = Data.Strings.MakeString(((UndertaleShader)obj).GLSL_ES_Fragment.Content);
                ((UndertaleShader)obj).GLSL_ES_Vertex = Data.Strings.MakeString(((UndertaleShader)obj).GLSL_ES_Vertex.Content);
                ((UndertaleShader)obj).GLSL_Fragment = Data.Strings.MakeString(((UndertaleShader)obj).GLSL_Fragment.Content);
                ((UndertaleShader)obj).GLSL_Vertex = Data.Strings.MakeString(((UndertaleShader)obj).GLSL_Vertex.Content);
                ((UndertaleShader)obj).HLSL9_Fragment = Data.Strings.MakeString(((UndertaleShader)obj).HLSL9_Fragment.Content);
                ((UndertaleShader)obj).HLSL9_Vertex = Data.Strings.MakeString(((UndertaleShader)obj).HLSL9_Vertex.Content);
                for (var i = 0; i < ((UndertaleShader)obj).VertexShaderAttributes.Count; i++)
                {
                    ((UndertaleShader)obj).VertexShaderAttributes[i].Name = Data.Strings.MakeString(((UndertaleShader)obj).VertexShaderAttributes[i].Name.Content);
                }
                return obj;
            }
            else if (obj is UndertaleSound)
            {
                ((UndertaleSound)obj).Name = Data.Strings.MakeString(((UndertaleSound)obj).Name.Content);
                ((UndertaleSound)obj).Type = Data.Strings.MakeString(((UndertaleSound)obj).Type.Content);
                ((UndertaleSound)obj).File = Data.Strings.MakeString(((UndertaleSound)obj).File.Content);
                return obj;
            }
            else if (obj is UndertaleSprite)
            {
                ((UndertaleSprite)obj).Name = Data.Strings.MakeString(((UndertaleSprite)obj).Name.Content);
                return obj;
            }
            else if (obj is UndertaleTextureGroupInfo)
            {
                ((UndertaleTextureGroupInfo)obj).Name = Data.Strings.MakeString(((UndertaleTextureGroupInfo)obj).Name.Content);
                return obj;
            }
            else if (obj is UndertaleTimeline)
            {
                ((UndertaleTimeline)obj).Name = Data.Strings.MakeString(((UndertaleTimeline)obj).Name.Content);
                return obj;
            }
            else if (obj is UndertaleTexturePageItem)
            {
                return obj;
            }
            else if (obj is UndertaleVariable)
            {
                ((UndertaleVariable)obj).Name = Data.Strings.MakeString(((UndertaleVariable)obj).Name.Content);
                return obj;
            }
            return obj;
        }
        public UndertaleSequence.Track RecurseTracks(UndertaleSequence.Track trackRecurse)
        {
            trackRecurse.ModelName = Data.Strings.MakeString(trackRecurse.ModelName.Content);
            trackRecurse.Name = Data.Strings.MakeString(trackRecurse.Name.Content);
            trackRecurse.GMAnimCurveString = Data.Strings.MakeString(trackRecurse.GMAnimCurveString.Content);
            if ((trackRecurse.ModelName.Content) == "GMStringTrack")
            {
                for (var j = 0; j < (trackRecurse.Keyframes as UndertaleSequence.StringKeyframes).List.Count; j++)
                {
                    for (var k = 0; k < (trackRecurse.Keyframes as UndertaleSequence.StringKeyframes).List[j].Channels.Count; k++)
                    {
                        (trackRecurse.Keyframes as UndertaleSequence.StringKeyframes).List[j].Channels[k].Value = Data.Strings.MakeString((trackRecurse.Keyframes as UndertaleSequence.StringKeyframes).List[j].Channels[k].Value.Content);
                    }
                }
            }
            for (var j = 0; j < trackRecurse.Tracks.Count; j++)
            {
                trackRecurse.Tracks[j] = RecurseTracks(trackRecurse.Tracks[j]);
            }
            return trackRecurse;
        }
    }
}
