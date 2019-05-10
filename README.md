# Subway Deep Learning

## Introduction
This project uses Unity ML-Agents to train intelligent agents in a abstract subway environment, on witch two types of agents must move to the other room to reach its goal.

## Como usar
Este reposit�rio j� � a pasta do projeto Unity. Para abri-lo, navegue at� a pasta *./Assets/Scenes* e abra o arquivo *Subway.unity*.

A pasta do reposit�rio tamb�m j� conta com o arquivo de configura��o para o treinamento: *./config*

O modelo treinado � salvo na pasta *models/Subway-0/SubwayBrain.nn*

Para treinar o modelo, certifique-se que seu ambiente est� de acordo com o especificado [aqui](https://github.com/Unity-Technologies/ml-agents/blob/master/docs/Training-ML-Agents.md) e execute o seguinte comando no terminal:
```
mlagents-learn ./config.yaml --run-id=Subway --train
```
