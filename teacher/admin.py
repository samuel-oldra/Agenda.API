from django.contrib import admin

from teacher.models import Professor, Aula


@admin.register(Professor)
class ProfessorAdmin(admin.ModelAdmin):
    list_display = ('nome', 'valor_hora', 'foto')


@admin.register(Aula)
class AulaAdmin(admin.ModelAdmin):
    list_display = ('nome', 'email', 'get_professor_nome')

    def get_professor_nome(self, obj):
        return obj.professor.nome

    get_professor_nome.short_description = 'Professor'