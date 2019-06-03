# Subway Deep Learning
This project uses Unity ML-Agents to train intelligent agents in a abstract subway environment, on witch two types of agents must move to the other room to reach its goal.

## Introdução
Este projeto implementa um modelo de Reinforcement Learning, com o objetivo de entender o funcionamento do algoritmo envolvido no seu treinamento, por meio de um jogo que simula um cenário para experimentos.

## Instruções
### Executar o jogo no Unity
Para executar o projeto o jogo é necessário instalar a última versão Unity 3D, certifique-se de selecionar na instalação o componente *Linux Build Support*.

Como este repositório já é a própria pasta do projeto Unity, clone-o em seu computador e abra esta pasta como projeto dentro do Unity.
```
$ git clone https://github.com/Leostayner/subway-deep-learning.git
```

Caso a cena principal do jogo não abra automaticamente, você pode fazer manualmente acessando a pasta `Assets > Scenes` e clicando em *Subway*.

Para executar o jogo para o último modelo treinado, acesse o objeto *Academy* e certifique-se que a opção *Control* esteja desmarcada.

Para selecionar outro modelo para os agentes, acesse o objeto Brain (por meio do sistema de arquivos: `Assets > Brains`) e arraste o modelo desejado.

### Treinar o modelo com ML-Agents
A biblioteca ML-Agents utiliza o Tensorflow 1.7, só disponível na versão 3.6 do Python. Para instalar o ambiente completo é recomendado que seja utilizado o [Anaconda](https://www.anaconda.com/) para criação de um ambiente virtual.

Com o Anaconda instalado, crie um ambiente virtual com Python 3.6 e ative-o:
```
$ conda create --n ml-agents python=3.6
$ conda activate ml-agents
```

Instale a biblioteca *mlagents* e suas dependências (incluindo o Tensorflow 1.7) com:
```
$ pip install mlagents
```

Agora, para treinar o modelo, entre na pasta do repositório que você clonou e execute o seguinte comando:
```
$ mlagents-learn config/trainer_config.yaml --curriculum=config/curricula/ --run-id=subway_curriculum --train
```

- `config/trainer_config.yaml` determina a localização do arquivo de configuração para o treinamento
- `--curriculum=config/curricula/` determina a localização do arquivo de configuração adicional para o treinamento do *curriculum learning*.
- `--run-id=subway_curriculum` identifica o treinamento com um ID específico que será mostrado no Tensorboard.

Todos os modelos (*AgentBrain.nn*) treinados serão salvos na pasta `models` e os dados do treinamento em `summaries`.

Caso queira acompanhar a evolução do treinamento pelo Tensorboard, digite o comando a seguir no terminal e acesse pelo navegador a URL indicada:
```
$ tensorboard --logdir=./summaries
```
