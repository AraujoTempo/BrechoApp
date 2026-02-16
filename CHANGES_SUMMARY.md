# Summary of Changes - CPF to CpfCnpj Property Rename

## Overview
This PR completes the database schema migration by renaming the `CPF` property and column to `CpfCnpj` throughout the codebase. This resolves the SQLite error "no such column: TipoParceiro" by ensuring all database schema, model properties, and code references are properly aligned.

---

## 🎯 Primary Change: CPF → CpfCnpj Property Rename

### What Changed:
The property and database column have been renamed from `CPF` to `CpfCnpj` to better reflect that this field accepts both:
- **CPF**: 11 digits (individuals - e.g., 123.456.789-09)
- **CNPJ**: 14 digits (companies - e.g., 11.222.333/0001-81)

### Technical Changes:
1. **Model Property**: Renamed `ParceiroNegocio.CPF` to `ParceiroNegocio.CpfCnpj`
2. **Database Column**: Renamed column from `CPF` to `CpfCnpj` in `ParceirosNegocio` table
3. **Repository Queries**: Updated all SQL queries (15 locations) to use `CpfCnpj` column
4. **Form Code**: Updated all property references (6 locations) from `.CPF` to `.CpfCnpj`
5. **Constants**: Renamed `CPF_DUMMY` to `CPFCNPJ_DUMMY`

---

## 🔒 Security & Quality

✅ **Code Review**: Passed with no issues  
✅ **Security Scan**: 0 vulnerabilities detected  
✅ **Data Integrity**: All validations updated correctly  
✅ **Consistency**: All references updated across 4 files

---

## 📁 Files Changed

### Modified Files (4):
- `BrechoApp/Models/ParceiroNegocio.cs` - Property renamed
- `BrechoApp/Data/DatabaseInitializer.cs` - Database column renamed
- `BrechoApp/Data/ParceiroNegocioRepository.cs` - All SQL queries updated
- `BrechoApp/FormCadastroParceiroNegocio.cs` - All property references updated

---

## ⚠️ Important Notes

### Database Migration Required
After merging this PR, users **MUST**:
1. **Close the application** completely
2. **Delete the `brecho.db` file** (development environment only)
3. **Restart the application** - the database will be recreated with the correct schema

> ⚠️ **Warning**: This is a breaking change for existing databases. The old `CPF` column will not be automatically migrated.

### Why This Change Was Needed
The previous implementation had a mismatch:
- The UI label showed "CPF/CNPJ"
- The validation accepted both CPF and CNPJ
- But the database column and model property were still named `CPF`

This PR completes the migration to `CpfCnpj` for consistency and clarity.

---

## 📊 Code Statistics

- **Total Changes**: 29 insertions, 29 deletions
- **Files Changed**: 4
- **SQL Queries Updated**: 15
- **Property References**: 6
- **Commits**: 2

---

## 🎉 Benefits

1. **Naming Consistency**: Property name matches its purpose (accepts both CPF and CNPJ)
2. **Code Clarity**: Developers immediately understand the field accepts both document types
3. **Error Resolution**: Fixes SQLite column mismatch errors
4. **Maintainability**: Consistent naming across database, model, and code

---

## ✅ Testing Recommendations

1. Delete existing `brecho.db` file
2. Run the application
3. Verify database is created with `CpfCnpj` column
4. Test creating a new partner with CPF
5. Test creating a new partner with CNPJ
6. Test editing existing partners
7. Test search functionality
8. Test Excel export

---

## 🔗 Related Work

This PR builds upon previous work that:
- ✅ Added `TipoParceiro` enum and database column (already implemented)
- ✅ Added CNPJ validation logic (already implemented)
- ✅ Updated UI labels to show "CPF/CNPJ" (already implemented)
- ✅ Now completes the migration by renaming the property and column (this PR)
