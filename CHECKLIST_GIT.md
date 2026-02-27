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
Abrir BrechoApp-expansao1.sln
        ↓
   Git → Pull (sincronizar)
        ↓
   Codificar / Fazer alterações
        ↓
   Commit frequente (a cada funcionalidade)
        ↓
   Push para o GitHub
        ↓
   Criar PR no GitHub (se necessário)
        ↓
   Voltar ao VS → Git → Fetch → Pull
        ↓
   Continuar trabalhando
```
