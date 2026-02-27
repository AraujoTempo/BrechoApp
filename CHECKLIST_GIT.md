# ✅ Checklist Git — Visual Studio (BrechoApp)

> Use este checklist para evitar que o Git fique desabilitado no Visual Studio
> após longas sessões de trabalho ou depois de criar PRs no GitHub.

---

## 🔑 Regra de Ouro

**Sempre abra o projeto pelo arquivo `.sln`, nunca pelo `.csproj`:**

```
BrechoApp-expansao1.sln   ← USAR ESTE
```

O Visual Studio precisa do arquivo `.sln` para manter a integração Git ativa.
Abrir somente pelo `.csproj` faz com que o painel Git fique desabilitado.

---

## ❓ O que é o arquivo `.sln` e como abrir por ele?

O arquivo `.sln` (**Solution file**) é o "arquivo mestre" do projeto. Ele diz ao
Visual Studio onde estão todos os arquivos do BrechoApp e ativa recursos como o Git.

### 📂 Passo a passo para abrir pelo `.sln`

**Método 1 — Windows Explorer (mais fácil):**

1. Pressione **`Win + E`** para abrir o Windows Explorer
2. Navegue até a pasta do projeto no seu computador
   - Geralmente em: `C:\Users\<seu nome>\source\repos\BrechoApp`
   - Ou em: `C:\Projetos\BrechoApp` (depende de onde você clonou)
3. Procure o arquivo **`BrechoApp-expansao1.sln`** — ele tem um ícone do Visual Studio
4. Dê **duplo clique** nele — o Visual Studio abrirá já com o Git ativo

**Método 2 — Pesquisa do Windows (se não souber onde está):**

1. Clique na lupa da barra de tarefas (ou pressione **`Win + S`**)
2. Digite: **`BrechoApp-expansao1.sln`**
3. Clique no resultado que aparecer — o VS abrirá automaticamente

**Método 3 — Visual Studio → Projetos Recentes:**

1. Abra o Visual Studio normalmente
2. Na tela inicial, procure **`BrechoApp-expansao1.sln`** na lista de projetos recentes
3. Clique nele — o Git será ativado

> ⚠️ **Diferença importante:**
> - `BrechoApp-expansao1.sln` → abre o projeto **completo** com Git ✅
> - `BrechoApp.csproj` → abre só o código, **sem Git** ❌
> - Pasta no GitHub.com → cria uma **cópia nova** num lugar diferente ❌

---

## ⛔ ATENÇÃO — Nunca Abra o VS pelo Link do GitHub

O site `https://github.com/AraujoTempo/BrechoApp` tem um botão **"Open in Visual Studio"** ou
permite clonar via URL. **Isso cria uma NOVA cópia do projeto em uma pasta diferente**
e o VS não saberá onde está o `.sln` — o Git ficará desabilitado.

**O correto é:**
1. Abrir o **Windows Explorer** (não o VS, não o GitHub)
2. Navegar até a pasta onde o projeto já está clonado (ex.: `C:\Projetos\BrechoApp`)
3. Dar duplo clique em **`BrechoApp-expansao1.sln`**

> 💡 Se não souber onde está a pasta do projeto:
> - No VS (mesmo sem Git): `File → Open → Project/Solution`
> - Ou pesquisar no Windows: `BrechoApp-expansao1.sln`

---

## 🔧 Situação Atual — Sincronizar VS Após Trabalho no GitHub

Se você fez um merge/PR no GitHub e quer atualizar o Visual Studio:

**Passo 1 — Abrir corretamente:**
- Fechar todo o Visual Studio
- Abrir via `BrechoApp-expansao1.sln` no Windows Explorer

**Passo 2 — Mudar para o branch principal (main):**
- No VS: canto inferior direito → clicar no nome do branch atual
- Selecionar **`main`** (ou `master`)
- Clicar em **Checkout**

**Passo 3 — Trazer o merge do GitHub para o VS:**
- No painel **Git Changes**: clicar em **↻ Fetch All**
- Depois clicar em **↓ Pull** (ou `Git → Pull`)
- Aguardar a mensagem "Everything is up-to-date"

**Passo 4 — Confirmar que o código está atualizado:**
- O painel **Git Repository** (`Git → Manage Branches`) deve mostrar o branch `main`
  sem setas pendentes (↑ push / ↓ pull)
- O código no editor deve refletir as últimas alterações do PR

---

## 📋 Antes de Começar a Trabalhar

- [ ] Abrir o Visual Studio pelo arquivo **`BrechoApp-expansao1.sln`**
- [ ] Confirmar que o painel **Git Changes** está visível (`Git → Git Changes` ou `Alt+F8`)
- [ ] Confirmar que o painel **Git Repository** está disponível (`Git → Manage Branches`)
- [ ] Fazer **Sync / Pull** para pegar as últimas mudanças do GitHub

---

## 📋 Durante o Trabalho (a cada 1-2 horas)

- [ ] Fazer **commit** das alterações prontas (commits pequenos e frequentes)
- [ ] Fazer **Push** para o GitHub regularmente — não acumular muitas horas sem push
- [ ] Salvar todos os arquivos antes do commit (`Ctrl+Shift+S`)

---

## 📋 Após Criar um PR no GitHub

1. [ ] Após criar ou revisar o PR no site do GitHub, voltar ao Visual Studio
2. [ ] Clicar em **↻ Fetch** no painel Git Changes (ou `Git → Fetch`)
3. [ ] Se o painel Git aparecer desabilitado/cinza:
   - Fechar a solução: `File → Close Solution`
   - Reabrir: `File → Recent Projects` → selecionar **`BrechoApp-expansao1.sln`**
4. [ ] Fazer **Pull** para sincronizar o branch local com o remoto

---

## 🚨 Quando o Git Ficar Desabilitado — Recuperação

Siga os passos nesta ordem até resolver:

**Passo 0 — Se abriu pelo GitHub.com ou pela URL:**
- Fechar o Visual Studio completamente
- Abrir o **Windows Explorer**, navegar até a pasta do projeto (ex.: `C:\Projetos\BrechoApp` — a pasta onde está o `BrechoApp-expansao1.sln`)
- Dar duplo clique em **`BrechoApp-expansao1.sln`** — o Git voltará automaticamente
- Se o Git já estiver ativo após isso, **pare aqui** (não precisa dos passos seguintes)

**Passo 1 — Reabrir os painéis Git:**
- `Git → Git Changes` (ou `Alt+F8`)
- `Git → Manage Branches`

**Passo 2 — Fechar e reabrir a solução:**
- `File → Close Solution`
- `File → Open → Project/Solution`
- Selecionar `BrechoApp-expansao1.sln`

**Passo 3 — Verificar o plugin de controle de versão:**
- `Tools → Options → Source Control`
- Em "Current source control plug-in" deve estar: **Git**
- Se estiver diferente, selecionar **Git** e clicar OK
- Reiniciar o Visual Studio

**Passo 4 — Reiniciar o Visual Studio completamente:**
- Fechar todo o Visual Studio
- Reabrir pelo `BrechoApp-expansao1.sln` (não pelo `.slnx` ou `.csproj`)

**Passo 5 — Limpar o cache do Visual Studio (último recurso):**
- Fechar o Visual Studio
- Apagar a pasta `.vs/` na raiz do projeto (é recriada automaticamente)
- Reabrir pelo `BrechoApp-expansao1.sln`

---

## ✅ Boas Práticas Gerais

| Prática | Por quê |
|---|---|
| Abrir sempre pelo `.sln` | VS precisa do `.sln` para manter o Git ativo |
| Commits frequentes | Evita perder trabalho e mantém o histórico limpo |
| Não rastrear arquivos `.db` | Arquivos de banco de dados bloqueiam o Git |
| Não rastrear `.docx`/`.xlsx` no projeto | Arquivos binários grandes tornam o Git lento |
| Fazer push antes de pausas longas | Evita conflitos e sessões expiradas |
| Não deixar branches de PR abertos por dias | Reduz conflitos e perda de contexto |

---

## 📁 Arquivos Que Nunca Devem Ser Rastreados Pelo Git

O arquivo `.gitignore` já está configurado para ignorar:

```
*.db          ← banco de dados SQLite (brecho.db)
*.db-wal      ← write-ahead log do SQLite
*.db-shm      ← shared memory do SQLite
*.sqlite
[Bb]in/       ← pasta de build
[Oo]bj/       ← pasta de compilação
.vs/          ← configurações locais do VS
```

Se algum desses arquivos aparecer em "Changes" no painel Git,
**não faça commit deles** — algo está errado.

---

## 🔗 Fluxo de Trabalho Recomendado

```
Abrir BrechoApp-expansao1.sln (Windows Explorer, duplo clique)
        ↓
   Git → Pull (branch main — pegar o merge mais recente)
        ↓
   Criar branch novo para a próxima funcionalidade
   (Git → New Branch → dar nome como "minha-nova-feature")
        ↓
   Codificar / Fazer alterações
        ↓
   Commit frequente (a cada funcionalidade)
        ↓
   Push para o GitHub
        ↓
   Criar PR no GitHub (se necessário)
        ↓
   Aguardar merge do PR no GitHub
        ↓
   Voltar ao VS → mudar para main → Git → Pull
        ↓
   Criar novo branch e repetir
```

---

## ⚠️ O Que NÃO Fazer

| ❌ Não fazer | ✅ Fazer em vez disso |
|---|---|
| Clicar em "Open in Visual Studio" no GitHub.com | Abrir `BrechoApp-expansao1.sln` no Windows Explorer |
| Abrir o VS e usar `File → Open → Folder` | Usar `File → Open → Project/Solution` e selecionar o `.sln` |
| Trabalhar diretamente no branch `main` | Criar um branch novo para cada funcionalidade |
| Acumular dias de trabalho sem push | Fazer push pelo menos uma vez por dia |
| Ignorar avisos de conflito | Resolver conflitos antes de continuar |
